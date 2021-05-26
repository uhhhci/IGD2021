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

    // valid decision types
    public enum Decision
    {
        Weapon,
        Row
    }

    // plays an annimation according to whether its action/decision phase and which kind of decision was made
    public void PlayActionPhaseAnimation(Decision decision)
    {
        // print($"animation decision: {decision}");
        if (PhaseHandler.phase == PhaseHandler.Phase.Decision)
        {
            if (decision == Decision.Weapon)
            {
                //print("Playing Anmation for Weapon ");
                playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.Dance);
            }
            else if (decision == Decision.Row)
            {
                //print("Playing Anmation for Row");
                playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.Wave);
            }
            else
            {
                //print($"Invalid Decision: {decision}");
                playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.IdleImpatient);
            }
        }
        else
        {
            // print("Decision is currently not allowed");
            playerMinifigController.PlaySpecialAnimation(MinifigControllerGroupW.SpecialAnimation.IdleImpatient);
        }
    }

    public void ChangeEquippedWeapon(WeaponDefinitions.WeaponType weapon)
    {
        print("ChangeEquippedWeapon triggered");
        if (phase == PhaseHandler.Phase.Decision)
        {
            print($"Changing Weapon to {selectedWeapon}");
            selectedWeapon = weapon;
        }
   
        else
        {
            print("Changing Weapon is currently not allowed");
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
