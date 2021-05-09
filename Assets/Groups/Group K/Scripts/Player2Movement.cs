using UnityEngine.InputSystem;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private float verticalMovement = 0.0f;
    private float counterclockwiseRotation = 0.0f;

    private void Start()
    {
        string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
        GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
    }

    private void OnMoveDpad(InputValue value)
    {
        Debug.Log("Player2Movement");
        Vector2 input = value.Get<Vector2>();
        input.Normalize();
        verticalMovement = input.y;
        if (input.x > 0)
            counterclockwiseRotation = 1.0f;
        else
           counterclockwiseRotation = 0.0f; 
    }

    public float GetBridge1VerticalMovement()
    {
        return verticalMovement;
    }
    public float GetCounterclockwiseRotation()
    {
        return counterclockwiseRotation;
    }
}
