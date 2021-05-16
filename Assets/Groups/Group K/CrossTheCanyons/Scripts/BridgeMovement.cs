using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float movementForce = 1.0f;
    public float rotationForce = 1.0f;

    public Player1Movement player1;
    public Player2Movement player2;

    // Update is called once per frame
    void FixedUpdate()
    {
        float bridgeHorizontalMovement = player1.GetBridge1HorizontalMovement();
        float bridgeVerticalMovement = player2.GetBridge1VerticalMovement();
        float rotationTorque = player1.GetClockwiseRotation() - player2.GetCounterclockwiseRotation();

        Vector3 movementVec = new Vector3(-bridgeVerticalMovement, 0.0f, bridgeHorizontalMovement);
        rb.AddForce(movementVec * movementForce * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddTorque(0, rotationTorque * rotationForce * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

    public void SetBridgeBody(Rigidbody bridge)
    {
        rb = bridge;
    }
}
