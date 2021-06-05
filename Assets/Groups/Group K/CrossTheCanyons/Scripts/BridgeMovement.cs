using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float movementForce = 1.0f;
    public float rotationForce = 1.0f;

    public HorizontalBridgeMovement horizontalPlayer;
    public VerticalBridgeMovement verticalPlayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        float bridgeHorizontalMovement = horizontalPlayer.GetBridgeHorizontalMovement();
        float bridgeVerticalMovement = verticalPlayer.GetBridgeVerticalMovement();
        float rotationTorque = horizontalPlayer.GetClockwiseRotation() - verticalPlayer.GetCounterclockwiseRotation();

        Vector3 movementVec = new Vector3(-bridgeVerticalMovement, 0.0f, bridgeHorizontalMovement);
        rb.AddForce(movementVec * movementForce * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddTorque(0, rotationTorque * rotationForce * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

    public void SetBridgeBody(Rigidbody bridge)
    {
        rb = bridge;
    }
}
