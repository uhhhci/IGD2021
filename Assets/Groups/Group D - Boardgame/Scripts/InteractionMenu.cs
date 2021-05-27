using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenu : MonoBehaviour
{
    /// all possible actions
    public PlayerAction[] actions;

    public float bobbleSpeed = 5f;
    public float boobleAmplitude = 0.5f;

    public Vector3 spriteOffset = new Vector3(1.2f, 0.0f, 0.0f); 

    private List<PlayerAction> possibleActions = new List<PlayerAction>(); // all actions which are currently avaible to, but not neccessary affordable by the player
    private int highlighted = 0; // currently "selected"/highlighted action, an index in possible actions

    private Vector3 neverSeen = new Vector3(0f, -2000f, 0f); // a location which is never seen by players

    // Update is called once per frame
    void Update()
    {
        updatePossibleActions();

        renderActiveSprites();
    }


    public PlayerAction getSelectedAction() {
        if (highlighted > possibleActions.Count) {
            return null;
        }
        return possibleActions[highlighted];
    }

    public void nextAction() {
        highlighted = (highlighted+1) % possibleActions.Count;
    }

    public void previousAction() {
        highlighted--;
        if (highlighted < 0) {
            highlighted = possibleActions.Count - 1;
        }
    }

    /// returns whether an action is currently selected
    public bool anActionIsSelected() {
        return possibleActions.Count > 0;
    }

    /// returns the AP costs of  the currently selected action
    /// must not be called when actionIsSelected() == false
    public int getSelectedActionAPCost() {
        return possibleActions[highlighted].requiredAP;
    }

    /// returns the credit costs of  the currently selected action
    /// must not be called when actionIsSelected() == false
    public int getSelectedActionCreditCost() {
        return possibleActions[highlighted].requiredCredits;
    }

    private void updatePossibleActions() {
        possibleActions.Clear();
        for (int i = 0; i < actions.Length; i++) {
            if (isActive(i)) {
                possibleActions.Add(actions[i]);
            }
        }
        if (highlighted >= possibleActions.Count) {
            highlighted = possibleActions.Count - 1;
        } else if (highlighted < 0) {
            highlighted = 0;
        }
    }

    /// returns whether the player can afford the given action (i.e. whether they have enough AP and credits)
    private bool canAfford(PlayerAction action) {
        return action.isUsable();
    }

    /// returns whether the given action is "in principle" currently available for the player,
    /// i.e. whether the action could be used in this state independently of the action's costs (AP + credits)
    private bool isActive(int i) {
        return actions[i].isPresent();
    }

    private void renderActiveSprites() {
        Vector3 nextPos = transform.position;

        for (int i = 0; i < actions.Length; i++) {
            if (isActive(i)) {
                // display/hide the "Unusable" overlay sprite when the player can (not) afford the action
                actions[i].setEnabled(canAfford(actions[i]));

                // render the sprite
                Vector3 spritePos = nextPos;

                float offset = 0f;
                if (possibleActions.Count > 0 && actions[i] == possibleActions[highlighted]) {
                    // "highlighted" sprite bobbles
                    spritePos.y += Mathf.Sin(Time.timeSinceLevelLoad * bobbleSpeed) * boobleAmplitude;

                    // TODO: show AP cost and credit price (if present) of this action in the HUD
                }

                actions[i].setPosition(spritePos);
                nextPos += spriteOffset;
            }
            else {
                // prevent this from being rendered
                actions[i].setPosition(neverSeen);
            }
        }
    }
}
