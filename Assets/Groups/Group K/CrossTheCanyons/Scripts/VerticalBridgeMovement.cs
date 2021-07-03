using UnityEngine.InputSystem;
using UnityEngine;

public class VerticalBridgeMovement : MonoBehaviour
{
    public InputManagerCTC inputManagerCTC;
    public BotControllerCTC botController;
    public int playerID;
    public bool leftPlayer;
    private bool isPlayerBot;
    private float verticalMovement = 0.0f;
    private float counterclockwiseRotation = 0.0f;

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
            Vector2 input = botController.GenerateInput(vertical: true, leftPlayer: leftPlayer);
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
        verticalMovement = input.y;
        if (input.x > 0)
            counterclockwiseRotation = 1.0f;
        else
           counterclockwiseRotation = 0.0f; 
    }

    public float GetBridgeVerticalMovement()
    {
        return verticalMovement;
    }
    public float GetCounterclockwiseRotation()
    {
        return counterclockwiseRotation;
    }
}
