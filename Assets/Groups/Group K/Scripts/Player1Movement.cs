using UnityEngine.InputSystem;
using UnityEngine;

public class Player1Movement : MonoBehaviour
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
        Debug.Log("Player1Movement");
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        horizontalMovement = input.x;
        if (input.y > 0)
            clockwiseRotation = 1.0f;
        else
           clockwiseRotation = 0.0f; 
    }

    public float GetBridge1HorizontalMovement()
    {
        return horizontalMovement;
    }

    public float GetClockwiseRotation()
    {
        return clockwiseRotation;
    }
}
