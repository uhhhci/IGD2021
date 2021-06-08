using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public enum Type {
        END_TURN,
        BUY_GOLDEN_BRICK,
        ITEM_CREDIT_THIEF,
        BUY_AP,
        SHOP,
        // TODO: add more actions here
    }

    public Type type;
    public int requiredAP;
    public int requiredCredits;

    public void setPosition(Vector3 newPos) {
        transform.position = newPos;
    }

    private bool actionIsPresent = false;
    private bool actionIsUsable = false;

    /// sets the status of this action
    public void updateStatus(bool present, bool usable) {
        actionIsPresent = present;
        actionIsUsable = usable;
    }

    /// whether this action could be used in principle in the given game state
    public bool isPresent() {
        return actionIsPresent;
    }

    /// whether the player can afford this action right now
    public bool isUsable() {
        return actionIsUsable;
    }

    /// call this method when this player action is available (true) or unavailble because of too few action points or credits (false)
    public void setEnabled(bool newValue) {
        // disable/enable rendering the child (Unused overlay sprite) of this sprite
        Component myRenderer = GetComponent(typeof(Renderer));
        Component[] renderers = GetComponentsInChildren(typeof(Renderer), true);
        foreach (Renderer renderer in renderers) {
            // GetComponentsInChildren returns also the renderer of the parent
            if (renderer != myRenderer) {
                renderer.enabled = !newValue;
            }
        }
    }
}
