using UnityEngine.InputSystem;
using UnityEngine;

public class HorizontalBridgeMovement : MonoBehaviour
{
    private float horizontalMovement = 0.0f;
    private float clockwiseRotation = 0.0f;

    private void Start()
    {
        string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
        GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
    }

    private void OnMoveDpad(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        horizontalMovement = input.x;
        if (input.y > 0)
            clockwiseRotation = 1.0f;
        else
           clockwiseRotation = 0.0f; 
    }

    public float GetBridgeHorizontalMovement()
    {
        return horizontalMovement;
    }

    public float GetClockwiseRotation()
    {
        return clockwiseRotation;
    }
}
