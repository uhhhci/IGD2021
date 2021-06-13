using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    private Rigidbody bridge;
    private float movementForce = 0.7f;
    private float rotationForce = 0.7f;

    public HorizontalBridgeMovement horizontalPlayer;
    public VerticalBridgeMovement verticalPlayer;

    void FixedUpdate()
    {
        float bridgeHorizontalMovement = horizontalPlayer.GetBridgeHorizontalMovement();
        float bridgeVerticalMovement = verticalPlayer.GetBridgeVerticalMovement();
        float rotationTorque = horizontalPlayer.GetClockwiseRotation() - verticalPlayer.GetCounterclockwiseRotation();

        Vector3 movementVec = new Vector3(-bridgeVerticalMovement, 0.0f, bridgeHorizontalMovement);
        bridge.AddForce(movementVec * movementForce * Time.deltaTime, ForceMode.VelocityChange);
        bridge.AddTorque(0, rotationTorque * rotationForce * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

    public void SetBridgeBody(Rigidbody bridge, bool isPlayerDead)
    {
        this.bridge = bridge;
        if (!isPlayerDead)
        {
            gameObject.AddComponent<FixedJoint>();
            GetComponent<FixedJoint>().connectedBody = bridge;
        }
    }

    public void DisconnectFromCrane()
    {
        Destroy(GetComponent<FixedJoint>());
    }
}
