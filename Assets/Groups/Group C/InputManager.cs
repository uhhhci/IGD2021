using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputManager : MonoBehaviour
{

    public GameObject _menuPlayerPrefab;
    private Controls controls;

    private const string INPUT_DEVICE_PLAYER = "InputDevideIDPlayer";
    private const string CONTROL_SCHEME_PLAYER = "ControlSchemePlayer";

    public static InputManager Instance;

    private void Awake () {
        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
            
        }
    }

    private void Start()
    {
        
    }

    public PlayerInput AssignPlayerInput(PlayerInput player, string playerId)
    {
        //Read values from PlayerPrefs
        int inputDeviceId = PlayerPrefs.GetInt(INPUT_DEVICE_PLAYER + playerId);
        string controlScheme = PlayerPrefs.GetString(CONTROL_SCHEME_PLAYER + playerId);

        player.SwitchCurrentControlScheme(controlScheme, Keyboard.current);

        return player;
        
    }

    private void SavePlayerControlScheme(string playerId, int inputDeviceId, string controlScheme)
    {
        PlayerPrefs.SetInt(INPUT_DEVICE_PLAYER + playerId, inputDeviceId);
        PlayerPrefs.SetString(CONTROL_SCHEME_PLAYER + playerId, controlScheme);
    }

    /*
    private void GetPlayerControlScheme(string playerId)
    {
        int inputDeviceId = PlayerPrefs.GetInt(INPUT_DEVICE_PLAYER + playerId);
        string controlScheme = PlayerPrefs.GetString(CONTROL_SCHEME_PLAYER + playerId);

        //var playerInput = PlayerInput.Instantiate( controlScheme, inputDeviceId);
        
    }
    */

    
    //Work in progress
    private void SpawnKeyboardPlayers()
    {
        PlayerControllerLobby player;
        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SwitchCurrentControlScheme(controls.KeyboardWASDScheme.name, Keyboard.current);

        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SwitchCurrentControlScheme(controls.KeyboardZGHJScheme.name, Keyboard.current);

        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SwitchCurrentControlScheme(controls.KeyboardPLÖÄScheme.name, Keyboard.current);

        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SwitchCurrentControlScheme(controls.KeyboardNumScheme.name, Keyboard.current);


    }

    private void SpawnControllerPlayers()
    {
        PlayerControllerLobby player;
        ReadOnlyArray<Gamepad> gamepads = Gamepad.all;

        for (int i = 0; i < gamepads.Count; i++)
        {
            player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
            player.SwitchCurrentControlScheme(controls.GamepadScheme.name, Gamepad.all[i]);
            
        }
    }
    
}

public class PlayerControllerLobby : PlayerInput
{

}
