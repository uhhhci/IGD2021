using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : MonoBehaviour
{
    public PhaseHandler.Phase phase;
    public TextAsset jsonFile;
    public WeaponTypes weaponTypes;

    // returns a damage multipler based on the equipped weapon type and the target weapon type strength/weakness
    float GetMultiplier(WeaponJsonReader.WeaponType equippedWeaponType, WeaponJsonReader.WeaponType targetWeaponType)
    {
        WeaponType equippedWeaponTypeInfo = Array.FindAll<WeaponType>(weaponTypes.weaponTypes, weaponType => weaponType.type == equippedWeaponType.ToString())[0];
        if(targetWeaponType.ToString() == equippedWeaponTypeInfo.strength)
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

    WeaponJsonReader.WeaponType GetTargetWeaponType(PlayerProperties.Team ownTeam, PlayerProperties.RowPosition targetRow)
    {
        // opponent team is the team that is not the own team
        PlayerProperties.Team opponentTeam = ownTeam == PlayerProperties.Team.Left ? PlayerProperties.Team.Right : PlayerProperties.Team.Left;
        foreach (Transform child in transform)
        {
            if(child.GetComponent<PlayerProperties>().team == opponentTeam && child.GetComponent<PlayerProperties>().rowPosition == targetRow)
            {
                return child.GetComponent<PlayerProperties>().weapon;
            }
        }

        // TODO this is ugly; if no weapon is equipped, no weapon type should be returned - but this should never happen anyway
        return WeaponJsonReader.WeaponType.Lego;

    }

    void Attack()
    {

        // calculate damage
        // pay attention to only access valid targets
        // lower hp of attacked players
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponTypes = JsonUtility.FromJson<WeaponTypes>(jsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        phase = PhaseHandler.phase;
 
        foreach (Transform child in transform)
        {
            // use team and targetRow to access target player
            PlayerProperties.Team ownTeam = child.GetComponent<PlayerProperties>().team;
            PlayerProperties.RowPosition targetRow = child.GetComponent<PlayerProperties>().targetRow;

            // use equippedWeaponType and targetWeaponType to calculate damage
            WeaponJsonReader.WeaponType equippedWeaponType = child.GetComponent<PlayerProperties>().weapon;
            WeaponJsonReader.WeaponType targetWeaponType = GetTargetWeaponType(ownTeam, targetRow);
            float multiplier = GetMultiplier(equippedWeaponType, targetWeaponType);
            print($"targetWeaponType: {targetWeaponType}");
            print($"multiplier: {multiplier}");
        }

        // print($"transform.name: {transform.name}");
        // print($"transform.parent: {transform.parent}");

        if (phase == PhaseHandler.Phase.Action)
        {
            // for each player (children of Players), attack sequentially
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
