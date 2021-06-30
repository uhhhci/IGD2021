using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DecisionPhase : MonoBehaviour
{
    public PhaseHandler.Phase phase;
    public WeaponDefinitions.WeaponType selectedWeapon;
    public PhaseHandler.RowPosition selectedTargetRow;
    public Vector3 leftHandPosition;
    public GameObject leftHandWeapon;
    PlayerProperties player;
    private MinifigControllerGroupW playerMinifigController;
    bool isDecisionPhase;

    // plays an annimation according to whether its action/decision phase and which kind of decision was made
    public void PlayChangeTargetRowAnimation(bool isLegal=true)
    {
        // print($"animation decision: {decision}");
        if (PhaseHandler.phase == PhaseHandler.Phase.Decision && isLegal && !player.IsAiPlayer)
        {
          playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.Wave);

        }
        else
        {
            print("Decision is currently not allowed");
            playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.IdleImpatient);
        }
    }

    
    public void ChangeEquippedWeapon(WeaponDefinitions.WeaponType weapon, ActionPhase actionPhase)
    {
        // print("ChangeEquippedWeapon triggered");
        if (phase == PhaseHandler.Phase.Decision && !player.IsAiPlayer)
        {
            selectedWeapon = weapon;
            print($"Changing Weapon to {selectedWeapon}");
            // just spawn a dummy weapon, such that it serves as feedback but does not reveal the actual selection
            actionPhase.ChangeLeftHandWeapon("Weapons/SA_Item_Fish");
        }
   
        else
        {
            print("Changing Weapon is currently not allowed");
            playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.IdleImpatient);
        }
    }

    public void ChangeTargetRow(PhaseHandler.RowPosition targetRow)
    {
        print("ChangeTargetRow triggered");
        if (phase == PhaseHandler.Phase.Decision)
        {
            print($"Changing TargetRow to {targetRow}");
            selectedTargetRow = targetRow;
        }
        else
        {
            print("Changing TargetRow is currently not allowed");
        }
    }

    // TODO call from ActionPhase instead, this is a duplicate right now
    void RemoveLeftHandWeapon()
    {
        if (leftHandWeapon != null)
        {
            DestroyImmediate(leftHandWeapon, true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // access specific PlayerProperties of the gameobject where this script is attached to
        player = gameObject.GetComponent<PlayerProperties>();
        playerMinifigController = gameObject.transform.parent.GetComponent<MinifigControllerGroupW>();
        leftHandPosition = player.leftHandPosition;
    }


    // Update is called once per frame
    void Update()
    {
        phase = PhaseHandler.phase;
        isDecisionPhase = phase == PhaseHandler.Phase.Decision;

        if (isDecisionPhase)
        {
            RemoveLeftHandWeapon();
        }
    }
}
