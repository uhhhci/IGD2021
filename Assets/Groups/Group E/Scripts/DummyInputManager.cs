using UnityEngine;
using UnityEngine.InputSystem;

public class DummyInputManager : MonoBehaviour
{
    private void Start()
    {
        PlayerInput[] playerInputs = GameObject.FindObjectsOfType<PlayerInput>();
        foreach(PlayerInput playerInput in playerInputs)
        {
            string controlScheme = playerInput.defaultControlScheme;
            playerInput.SwitchCurrentControlScheme(controlScheme, Keyboard.current);
        }
    }
}
