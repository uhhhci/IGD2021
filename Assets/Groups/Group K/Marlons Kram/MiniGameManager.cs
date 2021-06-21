using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

// TODO sort ranking for finished method
public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [SerializeField] private GameObject _player3;
    [SerializeField] private GameObject _player4;
    public GameObject _arena;

    [Header("AI Parameters")]
    public float AI_idleTime = 1.0f;
    public float AI_PlayerDetectRadius = 5.0f;
    public float AI_StunnedPreferationMultiplier = 1.3f;
    public float AI_HuntDelay = 1.0f;
    public float AI_KickDistance = 1.0f;
    public float AI_WaveDetectionRadius = 1.0f;
    public float AI_WaveDodgePercentage = 1.0f;
    public float AI_JumpPenalty = 0.5f;
    public float AI_StunDuration = 1.0f;
    public float AI_SinkingTolerance = 0.5f;
    public float AI_MeteorFleeDistance = 2.0f;
    public float AI_MeteorTolerance = 3.0f;

    private MiniGame _minigame;

    private void Awake()
    {
        _minigame = transform.GetComponent<MiniGame_Meteorfall>();

        List<PlayerInput> playerInputs = new List<PlayerInput>(4)
        {
            _player1.GetComponent<PlayerInput>(),
            _player2.GetComponent<PlayerInput>(),
            _player3.GetComponent<PlayerInput>(),
            _player4.GetComponent<PlayerInput>()
        };
        List<string> ids = new List<string>(4)
        {
            "0",
            "1",
            "2",
            "3"
        };

        bool player1_AI = PlayerPrefs.GetString("Player1_AI").Equals("True");
        bool player2_AI = PlayerPrefs.GetString("Player2_AI").Equals("True");
        bool player3_AI = PlayerPrefs.GetString("Player3_AI").Equals("True");
        bool player4_AI = PlayerPrefs.GetString("Player4_AI").Equals("True");
        player3_AI = true;
        player4_AI = true;
        player2_AI = true;
        //player1_AI = true;
        AssignAI(player1_AI, player2_AI, player3_AI, player4_AI);

        //InputManager.Instance.AssignPlayerInput(playerInputs); // Stops execution of this monobehaviour in absence of playerprefs
        //InputManager.Instance.AssignPlayerInput(playerInputs, ids); // Right Version when Playerprefs work correctly
    }

    // Update is called once per frame
    void Update()
    {
        bool aB1 = _player1.activeSelf;
        bool aB2 = _player2.activeSelf;
        bool aB3 = _player3.activeSelf;
        bool aB4 = _player4.activeSelf;

        if (aB1 && !(aB2 || aB3 || aB4))
        {
            WinGame(0);
        }
        else if (aB2 && !(aB1 || aB3 || aB4))
        {
            WinGame(1);
        }
        else if (aB3 && !(aB1 || aB2 || aB4))
        {
            WinGame(2);
        }
        else if (aB4 && !(aB2 || aB3 || aB1))
        {
            WinGame(3);
        }
        else if(!(aB1 || aB2 || aB3 || aB4))
        {
            List<GameObject> winners = new List<GameObject>();

            if (aB1) { winners.Add(_player1); };
            if (aB2) { winners.Add(_player2); };
            if (aB3) { winners.Add(_player3); };
            if (aB4) { winners.Add(_player4); };

            GameDraw(winners);
        }
    }

    public void GameDraw(List<GameObject> winners)
    {
        Debug.Log("Its a Draw!");
        int[] placeholder = new int[4] { 0, 1, 2, 3 };
        _minigame.MiniGameFinished(placeholder, new int[0], new int[0], new int[0]);
    }

    public void WinGame(int index)
    {
        Debug.Log("Player " + index + " Wins the Game!");
        int[] numbers = { 0, 1, 2, 3};
        numbers = numbers.Where(val => val != index).ToArray();
        _minigame.MiniGameFinished(new int[1] { index }, numbers, new int[0], new int[0]);
    }

    public void AssignAI(bool p1, bool p2, bool p3, bool p4)
    {
        if(p1)
        {
            _player1.AddComponent<MeteorFallAI>();
        }
        if (p2)
        {
            _player2.AddComponent<MeteorFallAI>();
        }
        if (p3)
        {
            _player3.AddComponent<MeteorFallAI>();
        }
        if (p4)
        {
            _player4.AddComponent<MeteorFallAI>();
        }
    }
}
