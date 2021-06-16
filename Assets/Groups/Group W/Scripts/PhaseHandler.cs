using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * Class used to switch between battle phases
 */
public class PhaseHandler : MonoBehaviour
{
    public static Phase phase;
    public static int roundCount;
    public static float timeLeft;
    public float maxDecisionPhaseSeconds = 5f;
    public float passedDecisionPhaseSeconds = 0f;
    public static float maxGameSeconds = 180f; // 180s = 3m
    public static float passedGameSeconds;
    public static List<PlayerProperties> players;
    public List<float> totalTeamHp;
    public static Team leadingTeam;

    public static int activePlayerIndex;
    public static int equippingPlayerIndex;
    public bool isActionPhaseFinished;
    public List<bool> havePlayersEquippedWeapons;
    public List<bool> arePlayerActionsOver;

    public enum Phase
    {
        Decision,
        Action,
        End
    }

    // TODO replace RowPosition / Team Enums with simple lists, allowing for more flexibility in the future
    public enum RowPosition
    {
        Front,
        Back
    }

    public enum Team
    {
        Left,
        Right
    }

    public static void SetNextActivePlayer()
    {
        activePlayerIndex += 1;
        print($"next active player: {activePlayerIndex}");
    }

    // Start is called before the first frame update
    void Start()
    {
        print($"calling from: {gameObject.name}");
        phase = Phase.Decision;
        roundCount = 1;

        // gather all players
        players = new List<PlayerProperties>();
        foreach (Transform child in transform)
        {
            players.Add(child.Find("LegoPaperScissors").GetComponent<PlayerProperties>());
            arePlayerActionsOver.Add(false);
            havePlayersEquippedWeapons.Add(false);
        }
        print($"initialized game with {players.Count} players");
        // set the first player active
        activePlayerIndex = 0;
        equippingPlayerIndex = 0;

        foreach (Team team in System.Enum.GetValues(typeof(Team)))
        {
            totalTeamHp.Add(0f);
        }
    }

    // game will end after time is passed or all players of a team are dead
    bool HasGameFinished()
    {
        // could write this more generic to be able to handle more teams, but will be enough right now
        return passedGameSeconds >= maxGameSeconds || totalTeamHp[0] == 0 || totalTeamHp[1] == 0;
    }

    void CalculateTeamHp()
    {
        Team[] teamValues = (Team[])System.Enum.GetValues(typeof(Team));
        for (int i = 0; i < teamValues.Length; i++)
        {
            totalTeamHp[i] = 0;
            foreach (PlayerProperties player in players)
            {
                if (player.team == teamValues[i])
                {
                    totalTeamHp[i] += player.currentHp;
                }
            }
        }

       // print($"totalTeamHp team left: {totalTeamHp[0]}");
       // print($"totalTeamHp team right: {totalTeamHp[1]}");
       GetLeadingTeam();
    }

    // returns the team which currently has the most hp
    void GetLeadingTeam()
    {
        // iterates the list 2 times => not performant, replace if this becomes a bottleneck
        int leadingTeamIndex = totalTeamHp.IndexOf(totalTeamHp.Max());
        leadingTeam = (Team)leadingTeamIndex;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO array with phases (interface phase), set index to active phase index, if(update active phase) increment index modulo

        CalculateTeamHp();
        if (HasGameFinished())
        {
            print("game is over now");
            phase = Phase.End;
            // TODO assign ranks
        }

        else
        {
            passedGameSeconds += Time.deltaTime;

            if (phase == Phase.Decision)
            {
                passedDecisionPhaseSeconds = passedDecisionPhaseSeconds += Time.deltaTime;
                timeLeft = maxDecisionPhaseSeconds - passedDecisionPhaseSeconds;

                if (passedDecisionPhaseSeconds >= maxDecisionPhaseSeconds)
                {
                    print("its action phase now");
                    phase = Phase.Action;
                }
            }

            if (phase == Phase.Action)
            {
                passedDecisionPhaseSeconds = 0f;
                isActionPhaseFinished = activePlayerIndex >= players.Count;

                if (isActionPhaseFinished)
                {
                    print("its decision phase now");
                    phase = Phase.Decision;
                    roundCount += 1;
                    activePlayerIndex = 0;
                    equippingPlayerIndex = 0;
                    arePlayerActionsOver = Enumerable.Repeat(false, players.Count).ToList();
                    havePlayersEquippedWeapons = Enumerable.Repeat(false, players.Count).ToList();
                }
                else
                {
                    // equip new weapon for each player, one time for each ActionPhase
                    foreach (PlayerProperties player in players)
                    {
                        if (equippingPlayerIndex < havePlayersEquippedWeapons.Count && !havePlayersEquippedWeapons[equippingPlayerIndex])
                        {
                            ActionPhase actionPhase = player.GetComponent<ActionPhase>();
                            actionPhase.ChangeLeftHandWeapon(player.rowPosition, player.weapon);
                            havePlayersEquippedWeapons[equippingPlayerIndex] = true;
                            equippingPlayerIndex++;
                        }

                    }

                    // each player attacks sequentially
                    // end if the last active player is finished
                    ActionPhase activePlayerActionPhase = players[activePlayerIndex].GetComponent<ActionPhase>();

                    if (!arePlayerActionsOver[activePlayerIndex])
                    {
                        activePlayerActionPhase.DoAction();
                        arePlayerActionsOver[activePlayerIndex] = true;
                    }
                }
            }
        }
    }
}
