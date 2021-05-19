using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public enum Type {
        END_TURN,
        BUY_GOLDEN_BRICK,
        // TODO: add more actions here
    }

    public Type type;
    public int requiredAP;

    public void setPosition(Vector3 newPos) {
        transform.position = newPos;
    }
}
