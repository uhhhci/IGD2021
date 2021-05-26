using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MinifigControllerGroupW : MinifigController
{
    // this is currently only experimental .. 
    PhaseHandler.Phase phase;
    DecisionPhase decisionPhase;

    private void OnMoveDpad(InputValue value)
    {
        //print("prevented moving through overriding");
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        if (input.Equals(Vector2.up))
        {
            print("selected Paper");
            decisionPhase.PlayActionPhaseAnimation(DecisionPhase.Decision.Weapon);
            decisionPhase.ChangeEquippedWeapon(WeaponDefinitions.WeaponType.Paper);
        }
    }

    // e.g. Q
    private void OnEastPress()
    {
        print("selected Lego");
        decisionPhase.PlayActionPhaseAnimation(DecisionPhase.Decision.Weapon);
        decisionPhase.ChangeEquippedWeapon(WeaponDefinitions.WeaponType.Lego);
    }


    private void OnSouthPress()
    {
        //print("prevented jumping through overriding");
        print("selected Scissors");
        decisionPhase.PlayActionPhaseAnimation(DecisionPhase.Decision.Weapon);
        decisionPhase.ChangeEquippedWeapon(WeaponDefinitions.WeaponType.Scissors);
    }

    // e.g. R
    private void OnNorthPress()
    {
        print("selected FrontRow");
        decisionPhase.PlayActionPhaseAnimation(DecisionPhase.Decision.Row);
        decisionPhase.ChangeTargetRow(PhaseHandler.RowPosition.Front);
    }

    // e.g. F
    private void OnWestPress()
    {
        print("selected BackRow");
        decisionPhase.PlayActionPhaseAnimation(DecisionPhase.Decision.Row);
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
        decisionPhase = GameObject.Find("LegoPaperScissors").GetComponent<DecisionPhase>();
    }
}


