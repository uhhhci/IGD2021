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

    public int height;

    public float decaySpeed = 0.2f;


    private float death_depth;

    private List<List<List<GameObject>>> _platforms;
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

        _platforms = Enumerable.Range(0, height).Select(h => {
            return Enumerable.Range(-length1 / 2, length1).Select(l1 => {
                return Enumerable.Range(-length2 / 2, length2).Select(l2 => {
                    var platform = Instantiate(pEnliS, position: new Vector3(l1, -4 * h, l2), rotation: transform.rotation);
                    //platform.AddComponent<playerDetection>();
                    var playerDetection = platform.GetComponent<playerDetection>();
                    playerDetection.bc = platform.GetComponent<BoxCollider>();
                    playerDetection.mr = platform.GetComponent<MeshRenderer>();
                    playerDetection.rb = platform.GetComponent<Rigidbody>();
                    playerDetection.decaySpeed = decaySpeed;
                    return platform;
                }).ToList();
            }).ToList();
        }).ToList();




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

    private void BlackDeath() =>
        players
            .Where(p => p.transform.position.y < death_depth)
            .Where(p => !dead_players.Contains(p))
            .ToList()
            .ForEach(dead_players.Enqueue);

    private int GameObject2Int(GameObject obj) => players.IndexOf(obj) + 1;

    void Update() {

        BlackDeath();

        if (dead_players.Count() == 4) {
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

    }
}
