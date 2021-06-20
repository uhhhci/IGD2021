using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MinifigControllerGroupW : MinifigController
{
    PhaseHandler.Phase phase;
    DecisionPhase decisionPhase;
    ActionPhase actionPhase;

    private void OnMoveDpad(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        if (input.Equals(Vector2.up))
        {
            print("selected Paper");
            decisionPhase.ChangeEquippedWeapon(WeaponDefinitions.WeaponType.Paper, actionPhase);
        }
    }

    // e.g. Q
    private void OnEastPress()
    {
        print("selected Lego");
        decisionPhase.ChangeEquippedWeapon(WeaponDefinitions.WeaponType.Lego, actionPhase);
    }


    private void OnSouthPress()
    {
        print("selected Scissors");
        decisionPhase.ChangeEquippedWeapon(WeaponDefinitions.WeaponType.Scissors, actionPhase);
    }

    // e.g. R
    private void OnNorthPress()
    {
        print("selected FrontRow");
        decisionPhase.PlayActionPhaseAnimation();
        decisionPhase.ChangeTargetRow(PhaseHandler.RowPosition.Front);
    }

    // e.g. F
    private void OnWestPress()
    {
        print("selected BackRow");
        decisionPhase.PlayActionPhaseAnimation();
        decisionPhase.ChangeTargetRow(PhaseHandler.RowPosition.Back);
    }


    // just to prevent the prints from MinifigController
    private void OnSouthRelease()
    {
    }

    private void OnWestRelease()
    {
    }

    private void OnNorthRelease()
    {
    }

    private void OnEastRelease()
    {
    }

    new void Update()
    {
        base.Update();
        phase = PhaseHandler.phase;
        decisionPhase = transform.Find("LegoPaperScissors").GetComponent<DecisionPhase>();
        actionPhase = transform.Find("LegoPaperScissors").GetComponent<ActionPhase>();
        // print($"player is {transform.name}, decision phase is from {decisionPhase.transform.parent.name}");
    }
}


