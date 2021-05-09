using UnityEngine;

public class LeftBridgeMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float movementForce = 1.0f;
    public float rotationForce = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Player1Movement player1 = FindObjectOfType<Player1Movement>();
        Player2Movement player2 = FindObjectOfType<Player2Movement>();
        float bridgeHorizontalMovement = player1.GetBridge1HorizontalMovement();
        float bridgeVerticalMovement = player2.GetBridge1VerticalMovement();
        float rotationTorque = player1.GetClockwiseRotation() - player2.GetCounterclockwiseRotation();

        Vector3 movementVec = new Vector3(-bridgeVerticalMovement, 0.0f, bridgeHorizontalMovement);
        rb.AddForce(movementVec * movementForce * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddTorque(0, rotationTorque * rotationForce * Time.deltaTime, 0, ForceMode.VelocityChange);
    }
}
