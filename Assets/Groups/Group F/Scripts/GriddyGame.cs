using System;
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
    public int yoffset;
    public int zoffset;

    public int height;

    public int gridoffset;

    public float decaySpeed = 0.2f;


    private float death_depth;

    private bool gameEnded = false;
    private List<GameObject> platforms = new List<GameObject>();
    private List<GameObject> dead_players = new List<GameObject>();
    private List<GameObject> players = new List<GameObject>();


    public override string getDisplayName() {
        return "Griddy Battle";
    }
    public override string getSceneName() {
        return "GriddyBattle";
    }

    public override MiniGameType getMiniGameType() {
        return MiniGameType.freeForAll;
    }

    private void Start() {
        death_depth = -4 * height - 10;

        Debug.Log($"death_depth = {death_depth}");
        
        platforms.Clear();
        for (int x=0;x<length1;x++) {
            for (int z=0;z<length2;z++) {
                for (int curh=0;curh<height;curh++) {
                    var platform = Instantiate(pEnliS, position: new Vector3(x * xoffset - gridoffset, -1 * yoffset * curh, z * zoffset - gridoffset), rotation: transform.rotation);
                    platforms.Add(platform);

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
            .ForEach(dead_players.Add);
        
        return dead_players.ToList();
    }


    private int GameObject2Int(GameObject obj) => players.IndexOf(obj) + 1;

    private void EndGame()
    {
        if (gameEnded) {
            return;
        }
        Debug.Log("GAME END");
        gameEnded = true;

        //Create array of positions with player ids, this also works in case there are multiple players in one position
        int[] first = { GameObject2Int(dead_players[3]) };
        int[] second = { GameObject2Int(dead_players[2]) };
        int[] third = { GameObject2Int(dead_players[1]) };
        int[] fourth = { GameObject2Int(dead_players[0]) };
        Debug.Log($"{first.First()} > {second.First()} > {third.First()} > {fourth.First()}");

        //Note this is still work in progress, but ideally you will use it like this
        MiniGameFinished(
            firstPlace: first, 
            secondPlace: second, 
            thirdPlace: third, 
            fourthPlace: fourth
        );
    }


    private DateTime _lastFollow = DateTime.Now;

    void Update() {
        BlackDeath();

        if (dead_players.Count() >= 4) {
            EndGame();
        }
        if ((DateTime.Now - _lastFollow).TotalSeconds > 0.4) {
            _lastFollow = DateTime.Now;
            foreach (var aiPlayer in GetAiPlayers()) {
                var goalCandidates = MinBy(platforms
                    .Where(p => Vector3.Distance(p.transform.position, aiPlayer.transform.position) < 5f)
                    .GroupBy(p => (int)(p.GetComponent<playerDetection>().decay * 10f)),
                        group => group.Key).ToList();

                var aiRotation = aiPlayer.transform.rotation;

                var goalPlatform = goalCandidates[new System.Random().Next() % goalCandidates.Count];
                //.MinBy(p => p.GetComponent<playerDetection>().decay);
                //var goalPlatform = MinBy(goalCandidates, p => p.GetComponent<playerDetection>().decay);

                //var goalVector = goalPlatform.transform.position - aiPlayer.transform.position;
                aiPlayer.GetComponent<MinifigController>().MoveTo(goalPlatform.transform.position);
            }
        }
    }


    public TSource MinBy<TSource, TKey>(IEnumerable<TSource> source,
    Func<TSource, TKey> selector) {
        if (source == null) throw new ArgumentNullException("source");
        if (selector == null) throw new ArgumentNullException("selector");
        var comparer = Comparer<TKey>.Default;

        using (var sourceIterator = source.GetEnumerator()) {
            if (!sourceIterator.MoveNext()) {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            var min = sourceIterator.Current;
            var minKey = selector(min);
            while (sourceIterator.MoveNext()) {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, minKey) < 0) {
                    min = candidate;
                    minKey = candidateProjected;
                }
            }
            return min;
        }
    }

    private List<GameObject> GetAiPlayers() {
        var aiPlayers = new List<GameObject>();
        if (PlayerPrefs.GetString("Player1_AI").Equals("True"))
            aiPlayers.Add(player1);
        //if (PlayerPrefs.GetString("Player2_AI").Equals("True"))
            aiPlayers.Add(player2);
        //if (PlayerPrefs.GetString("Player3_AI").Equals("True"))
            aiPlayers.Add(player3);
        //if (PlayerPrefs.GetString("Player4_AI").Equals("True"))
            aiPlayers.Add(player4);

        return aiPlayers;
    }
}
