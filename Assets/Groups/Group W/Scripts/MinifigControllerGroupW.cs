using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MinifigControllerGroupW : MinifigController
{
    // TODO outsource some parts to DecisionPhase.cs?
    // this is currently only experimental .. 

    public PhaseHandler.Phase phase;

    private void OnMoveDpad(InputValue value)
    {
        print("prevented moving through overriding");
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        if (input.Equals(Vector2.up))
        {
            print("selected Paper");
            PlayActionPhaseAnimation(Decision.Weapon);
        }
    }

    // e.g. Q
    private void OnEastPress()
    {
        print("selected Lego");
        PlayActionPhaseAnimation(Decision.Weapon);
    }


    private void OnSouthPress()
    {
        print("prevented jumping through overriding");
        print("selected Scissors");
        PlayActionPhaseAnimation(Decision.Weapon);
    }

    // e.g. R
    private void OnNorthPress()
    {
        print("selected FrontRow");
        PlayActionPhaseAnimation(Decision.Row);
    }

    // e.g. F
    private void OnWestPress()
    {
        print("Selected BackRow");
        PlayActionPhaseAnimation(Decision.Row);
    }


    #region Lego-Paper-Scissors specifc methods
    // plays an annimation according to whether its action/decision phase and which kind of decision was made
    private void PlayActionPhaseAnimation(Decision decision)
    {
        print($"animation decision: {decision}");
        if (PhaseHandler.phase == PhaseHandler.Phase.Decision)
        {
            if (decision == Decision.Weapon)
            {
                print("Playing Anmation for Weapon ");
                PlaySpecialAnimation(SpecialAnimation.Dance);
            }
            else if (decision == Decision.Row)
            {
                print("Playing Anmation for Row");
                PlaySpecialAnimation(SpecialAnimation.Wave);
            }
            else
            {
                print($"Invalid Decision: {decision}");
                PlaySpecialAnimation(SpecialAnimation.IdleImpatient);
            }
        }
        else
        {
            print("Decision is currently not allowed");
            PlaySpecialAnimation(SpecialAnimation.IdleImpatient);
        }
    }
    #endregion

    // valid decision types
    public enum Decision
    {
        Weapon,
        Row
    }

    void update()
    {
        phase = PhaseHandler.phase;
    }
}


