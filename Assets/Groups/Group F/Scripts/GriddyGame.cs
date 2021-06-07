using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.InputSystem;

public class GriddyGame : MiniGame {

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject pEnliS;

    public int length1;
    public int length2;

    public int xoffset;
    public int zoffset;

    public int height;

    public int gridoffset;

    public float decaySpeed = 0.2f;


    private float death_depth;

    private List<GameObject> _platforms = new List<GameObject>();
    private Queue<GameObject> dead_players = new Queue<GameObject>();
    private List<GameObject> players = new List<GameObject>();


    public override string getDisplayName() {
        return "Griddy Battle";
    }
    public override string getSceneName() {
        return "Sadness Is Rebellion";
    }

    public override MiniGameType getMiniGameType() {
        return MiniGameType.freeForAll;
    }

    private void Start() {
        death_depth = -4 * height - 10;

        for (int x=0;x<length1;x++) {
            for (int z=0;z<length2;z++) {
                for (int curh=0;curh<height;curh++) {
                    var platform = Instantiate(pEnliS, position: new Vector3(x * xoffset - gridoffset, -4 * curh, z * zoffset - gridoffset), rotation: transform.rotation);
                    _platforms.Add(platform);

                    var playerDetection = platform.GetComponent<playerDetection>();
                    playerDetection.bc = platform.GetComponent<BoxCollider>();
                    playerDetection.mr = platform.GetComponent<MeshRenderer>();
                    playerDetection.rb = platform.GetComponent<Rigidbody>();
                    playerDetection.decaySpeed = decaySpeed;
                }
            }
        }


        //Create list of player inputs from the players in the scene
        players = new List<GameObject> {
            player1,
            player2,
            player3,
            player4
        };
        var playerInputs = players.Select(p => p.GetComponent<PlayerInput>()).ToList();

        //This assigns the player input in the order they were given in the array
        InputManager.Instance.AssignPlayerInput(playerInputs);

    }

    private List<GameObject> BlackDeath() {
        players
            .Where(p => !dead_players.Contains(p))
            .Where(p => p.transform.position.y < death_depth)
            .ToList()
            .ForEach(dead_players.Enqueue);
        
        return dead_players.ToList();
    }


    private int GameObject2Int(GameObject obj) => players.IndexOf(obj) + 1;

    private void EndGame()
    {
        //Create array of positions with player ids, this also works in case there are multiple players in one position
        int[] first = { GameObject2Int(dead_players.Dequeue()) };
        int[] second = { GameObject2Int(dead_players.Dequeue()) };
        int[] third = { GameObject2Int(dead_players.Dequeue()) };
        int[] fourth = { GameObject2Int(dead_players.Dequeue()) };
        Debug.Log($"{first.First()} > {second.First()} > {third.First()} > {fourth.First()}");

        //Note this is still work in progress, but ideally you will use it like this
        MiniGameFinished(
            firstPlace: first, 
            secondPlace: second, 
            thirdPlace: third, 
            fourthPlace: fourth
        );
    }
    void Update() {
        BlackDeath();

        if (dead_players.Count() >= 4) {
            EndGame();
        }
    }
}
