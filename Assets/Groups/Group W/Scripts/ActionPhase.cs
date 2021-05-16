using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : MonoBehaviour
{
    public PhaseHandler.Phase phase;
    public static bool isActionPhaseFinished;
    public TextAsset jsonFile;
    public WeaponTypes weaponTypes;
    public static List<PlayerProperties> players;

    public bool previousActionFinished;
    public bool isAttackFinished;
    private float moveStopDistance = 1f;

    // calculates the damage dealt by currentPlayer to targetPlayer
    // takes the base damage and its multiplier (derived from the weapon types) into account
    float CalculateDamage(PlayerProperties currentPlayer, PlayerProperties targetPlayer)
    {
        Weapon[] matchingWeapons = WeaponDefinitions.GetWeapon(currentPlayer.weapon, currentPlayer.rowPosition);
        if (matchingWeapons.Length > 0)
        {
            int baseDamage = Int16.Parse(matchingWeapons[0].power);
            float multiplier = GetMultiplier(currentPlayer.weapon, targetPlayer.weapon);
            return baseDamage * multiplier;
        }

        else
        {
            return 0f;
        }
    }

    // returns a damage multipler based on the equipped weapon type and the target weapon type strength/weakness
    float GetMultiplier(WeaponDefinitions.WeaponType equippedWeaponType, WeaponDefinitions.WeaponType targetWeaponType)
    {
        WeaponType equippedWeaponTypeInfo = Array.FindAll<WeaponType>(weaponTypes.weaponTypes, weaponType => weaponType.type == equippedWeaponType.ToString())[0];
        if (targetWeaponType.ToString() == equippedWeaponTypeInfo.strength)
        {
            return 2f;
        }

        else if (targetWeaponType.ToString() == equippedWeaponTypeInfo.weakness)
        {
            return 0.5f;
        }

        else
        {
            return 1f;
        }
    }

    // searches for the player of the other team by chosing the other team and the target row
    PlayerProperties GetTargetPlayer(PlayerProperties.Team ownTeam, PlayerProperties.RowPosition targetRow)
    {
        // opponent team is the team that is not the own team
        PlayerProperties.Team opponentTeam = ownTeam == PlayerProperties.Team.Left ? PlayerProperties.Team.Right : PlayerProperties.Team.Left;
        List<PlayerProperties> matchingPlayers = players.FindAll(player => player.team == opponentTeam
                                                && player.rowPosition == targetRow);

        if (matchingPlayers.Count > 0)
        {
            return matchingPlayers[0];
        }
        
        else
        {
            // no player found
            throw new InvalidOperationException();
        }
    }

    // moves to the target and attacks it
    void AttackTarget(PlayerProperties activePlayer, PlayerProperties targetPlayer)
    {
        previousActionFinished = false;
        var minifigController = activePlayer.GetComponent<MinifigController>();
        Vector3 targetPosition = targetPlayer.transform.position;
        // stop *in front of* target character, not on top
        targetPosition.z -= moveStopDistance;
        minifigController.MoveTo(targetPosition, onComplete: () => { Attack(activePlayer, targetPlayer); });
    }

    void ReturnToStartPosition(PlayerProperties activePlayer, PlayerProperties targetPlayer)
    {
        var minifigController = activePlayer.GetComponent<MinifigController>();
        minifigController.MoveTo(activePlayer.startPosition, onComplete: () => { RotateBack(activePlayer, targetPlayer); });
        // TODO face to the correct direction again! (change rotation)
    }

    void RotateBack(PlayerProperties activePlayer, PlayerProperties targetPlayer)
    {
        print("now rotating back");
        var minifigController = activePlayer.GetComponent<MinifigController>();
        // activePlayer.startPosition
        // Vector3 originalRotation = new Vector3(5f, 5f, 5f);
        Vector3 originalRotation = targetPlayer.transform.position;
        minifigController.TurnTo(originalRotation, onComplete: () => { SetNextActivePlayer(activePlayer); });
    }

    void Attack(PlayerProperties activePlayer, PlayerProperties targetPlayer)
    {
        var minifigController = activePlayer.GetComponent<MinifigController>();
        //minifigController.PlaySpecialAnimation(MinifigController.SpecialAnimation.Stretching);

        // calculate damage
        float damage = CalculateDamage(activePlayer, targetPlayer);

        if(targetPlayer.currentHp >0)
        {
            // TODO play attack animation
            // lower hp of targed
            targetPlayer.currentHp -= damage;
            if (targetPlayer.currentHp > 0)

            {
                print($"damage to target ({targetPlayer.name}): {damage}");
                print($"new hp of target: {targetPlayer.currentHp}");
                // TODO play dying animation and prevent player from further being attacked

                if(targetPlayer.currentHp <= 0)
                {
                    print($"target player ({targetPlayer.name}) is dead now");
                }
            }
        }

        else
        {
            print($"target ({targetPlayer.name}) is already dead");
        }

        // finish attack
        print("finished attack");
        ReturnToStartPosition(activePlayer, targetPlayer);
    }

    void SetNextActivePlayer(PlayerProperties activePlayer)
    {
        activePlayer.isActive = false;
        int nextPlayerIndex = players.IndexOf(activePlayer) + 1;
        if (nextPlayerIndex < players.Count)
        {
            print($"next active player is: {players[nextPlayerIndex].name}");
            players[nextPlayerIndex].isActive = true;
            previousActionFinished = true;
            print($"player.isActive: {players[nextPlayerIndex].isActive}");
        }

        else
        {
            print("active phase is over now");
            previousActionFinished = true;
            isActionPhaseFinished = true;
            // begin next phase
            players[0].isActive = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponTypes = JsonUtility.FromJson<WeaponTypes>(jsonFile.text);

        // gather all players
        players = new List<PlayerProperties>();
        foreach (Transform child in transform)
        {
            players.Add(child.GetComponent<PlayerProperties>());
        }

        // set the first player active
        players[0].isActive = true;
        previousActionFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        phase = PhaseHandler.phase;

        if (phase == PhaseHandler.Phase.Action)
        {
            // each player attacks sequentially
            List<PlayerProperties> activePlayers = players.FindAll(player => player.isActive);

            if (activePlayers.Count == 1)
            {
                PlayerProperties activePlayer = activePlayers[0];
                PlayerProperties targetPlayer = GetTargetPlayer(activePlayer.team, activePlayer.targetRow);

                // if the preceding player is finished, its the next ones turn
                if (previousActionFinished)
                {
                    print($"current active player is {activePlayer.name}");
                    AttackTarget(activePlayer, targetPlayer);
                }
            }

            else
            {
                print($"Only exactly 1 active player is allowed to exist, but there were {activePlayers.Count}");
            }
        }
       
    }
}


[System.Serializable]
public class WeaponTypes
{
    public WeaponType[] weaponTypes;
}


[System.Serializable]
public class WeaponType
{
    public string type;
    public string weakness;
    public string strength;
}
