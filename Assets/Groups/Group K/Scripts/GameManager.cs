using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody leftBridge;
    public LeftBridgeMovement leftBridgeMovement;

    public void ReleaseBridgeSegments()
    {
        leftBridge.useGravity = true;
        leftBridgeMovement.enabled = false;
    }
}
