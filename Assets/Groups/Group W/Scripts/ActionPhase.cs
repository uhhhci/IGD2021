using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : MonoBehaviour
{
    public PhaseHandler.Phase phase;
    public TextAsset jsonFile;
    public WeaponTypes weaponTypes;
    private List<PlayerProperties> players;


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

    void Attack(PlayerProperties currentPlayer, PlayerProperties targetPlayer)
    {
        // TODO pay attention to only access valid targets
        // lower hp of attacked players

        // calculate damage
        float damage = CalculateDamage(currentPlayer, targetPlayer);

        if(targetPlayer.currentHp >0)
        {
            targetPlayer.currentHp -= damage;
            if (targetPlayer.currentHp > 0)

            {
                print($"damage: {damage}");
                print($"new hp of target player: {targetPlayer.currentHp}");
                // TODO play dying animation and prevent player from further being attacked
                print("target player is dead now");
            }

        }

        else
        {
            print("player is already dead");
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
    }

    // Update is called once per frame
    void Update()
    {
        phase = PhaseHandler.phase;

        if (phase == PhaseHandler.Phase.Action)
        {
            // each player should attack sequentially
            foreach (PlayerProperties player in players)
            {
                // access target player
                // PlayerProperties currentPlayer = player.GetComponent<PlayerProperties>();
                PlayerProperties targetPlayer = GetTargetPlayer(player.team, player.targetRow);

                Attack(player, targetPlayer);
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
