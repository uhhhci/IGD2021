using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class InputManager : MonoBehaviour
{


    //public GameObject _menuPlayerPrefab;
    private Controls controls;

    private const string INPUT_DEVICE_PLAYER = "InputDevideIDPlayer";
    private const string CONTROL_SCHEME_PLAYER = "ControlSchemePlayer";

    //AI PLayers keys
    public const string PLAYER_1_AI = "PLAYER1_AI";
    public const string PLAYER_2_AI = "PLAYER2_AI";
    public const string PLAYER_3_AI = "PLAYER3_AI";
    public const string PLAYER_4_AI = "PLAYER4_AI";


    private List<Tuple<int, int, string>> playerSchemes = new List<Tuple<int, int, string>>();

    public GameObject _menuPlayerPrefab;
    public List<Color> players_colors = new List<Color>{Color.red, Color.yellow, Color.magenta, Color.blue};
    public List<string> players_colors_names = new List<string>{"RED", "YELLOW", "PINK", "BLUE"};
    public List<int> ids_players = new List<int>{1, 2, 3, 4};

    //CustomCharacter player1 = new CustomCharacter();
    //CustomCharacter player2 = new CustomCharacter();
    //CustomCharacter player3 = new CustomCharacter();
    //CustomCharacter player4 = new CustomCharacter();

    //public List<CustomCharacter> players_minifigs = new List<CustomCharacter>{player1, player2, player3, player4};

    public static InputManager Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }

    private void Start()
    {
        //SpawnKeyboardPlayers();
        SaveAIPlayers(true, false, false, false);
    }

    //Assign control scheme that was read from the character selection
    public List<PlayerInput> AssignPlayerInput(List<PlayerInput> players, List<string> playerIds)
    {

        for (int i = 0; i < players.Count; i++)
        {
            //Read values from PlayerPrefs
            int inputDeviceId = PlayerPrefs.GetInt(INPUT_DEVICE_PLAYER + playerIds[i]);
            string controlScheme = PlayerPrefs.GetString(CONTROL_SCHEME_PLAYER + playerIds[i]);

            players[i].SwitchCurrentControlScheme(controlScheme, InputSystem.GetDeviceById(inputDeviceId));
        }

        return players;

    }

    //This will assign player control schemes on the order they are received
    // WASD, ZGHJ, PLOA, NUM
    //The return is in case you need to save the modified instance again. However it should still work without using the returned value
    public List<PlayerInput> AssignPlayerInput(List<PlayerInput> players)
    {

        controls = new Controls();

        List<InputControlScheme> controlSchemes = new List<InputControlScheme> {
            controls.KeyboardWASDScheme,
            controls.KeyboardZGHJScheme,
            controls.KeyboardPLÖÄScheme,
            controls.KeyboardNumScheme
        };

        for (int i = 0; i < players.Count; i++)
        {
            players[i].SwitchCurrentControlScheme(controlSchemes[i].name, Keyboard.current);
        }


        return players;

    }


    private void SavePlayerControlScheme(string playerId, int inputDeviceId, string controlScheme)
    {
        PlayerPrefs.SetInt(INPUT_DEVICE_PLAYER + playerId, inputDeviceId);
        PlayerPrefs.SetString(CONTROL_SCHEME_PLAYER + playerId, controlScheme);
    }

    //This should be called at the end of the selection screen
    public void SavePlayersControlSchemes()
    {
        //Iterate over all tuples
        foreach (Tuple<int, int, string> player in playerSchemes)
        {
            SavePlayerControlScheme(player.Item1.ToString(), player.Item2, player.Item3);
        }
    }

    public void AddControlScheme(Tuple<int, int, string> playerScheme)
    {
        //Check if the tuple is already in the list
        if (playerSchemes.Count == 0)
        {
            playerSchemes.Add(playerScheme);
        }
        else
        {
            if (!playerSchemes.Contains(playerScheme))
            {
                playerSchemes.Add(playerScheme);
            }
        }
    }

    //MEthos sets the values of which player is AI and which not, should only be called on the Character selection scene
    public void SaveAIPlayers(bool firstPlayer, bool secondPlayer, bool thirdPlayer, bool fourthPlayer )
    {
        PlayerPrefs.SetString(PLAYER_1_AI, firstPlayer.ToString());
        PlayerPrefs.SetString(PLAYER_2_AI, secondPlayer.ToString());
        PlayerPrefs.SetString(PLAYER_3_AI, thirdPlayer.ToString());
        PlayerPrefs.SetString(PLAYER_4_AI, fourthPlayer.ToString());

        //Example of how to retrieve them
        bool player1_AI = PlayerPrefs.GetString(PLAYER_1_AI).Equals("True");
        print("AI player value === " + player1_AI.ToString());
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
    //This will be used when players select their character at the start screen

    private void SpawnKeyboardPlayers()
    {
        controls = new Controls();

        PlayerControllerLobby player;
        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SetInputDeviceAndControlScheme(controls.KeyboardWASDScheme.name, Keyboard.current);

        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SetInputDeviceAndControlScheme(controls.KeyboardZGHJScheme.name, Keyboard.current);

        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SetInputDeviceAndControlScheme(controls.KeyboardPLÖÄScheme.name, Keyboard.current);

        player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
        player.SetInputDeviceAndControlScheme(controls.KeyboardNumScheme.name, Keyboard.current);


    }

    /*
    private void SpawnControllerPlayers()
    {
        PlayerControllerLobby player;
        ReadOnlyArray<Gamepad> gamepads = Gamepad.all;

        for (int i = 0; i < gamepads.Count; i++)
        {
            player = PlayerInput.Instantiate(_menuPlayerPrefab).GetComponent<PlayerControllerLobby>();
            player.SwitchCurrentControlScheme(controls.GamepadScheme.name, Gamepad.all[i]);
            
        }
    } */


}

