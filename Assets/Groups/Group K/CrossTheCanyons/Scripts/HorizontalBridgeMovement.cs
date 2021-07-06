using UnityEngine.InputSystem;
using UnityEngine;

public class HorizontalBridgeMovement : MonoBehaviour
{
    public InputManagerCTC inputManagerCTC;
    public BotControllerCTC botController;
    public int playerID;
    public bool leftPlayer;
    private bool isPlayerBot;
    private float horizontalMovement = 0.0f;
    private float clockwiseRotation = 0.0f;

    private void Start()
    {
        string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
        GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
        isPlayerBot = inputManagerCTC.IsPlayerBot(playerID);
    }

    private void Update() 
    {
        if (isPlayerBot)
        {
            Vector2 input = botController.GenerateInput(vertical: false, leftPlayer: leftPlayer);
            UpdateMovement(input);
        }
    }

    private void OnMoveDpad(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        UpdateMovement(input);
    }

    private void UpdateMovement(Vector2 input)
    {
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
