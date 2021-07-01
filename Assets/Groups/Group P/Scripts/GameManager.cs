using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace GroupP {
    public class GameManager : MiniGame
    {
        private static GameManager _instance;

        public static GameManager instance { get { return _instance; }}

        public GameObject player1, player2, player3, player4;

        public List<GameObject> songs = new List<GameObject>();

        public bool startPlaying;

        public int songIndex = -1;

        public NoteSystem noteSystem;     //<-- Tutorial: BeatScroller theBS (theBS === noteSystem)

        float beatsPerMinute;

        public float getBpmOfActiveSong() {
            return songs[songIndex].GetComponent<Song>().beatsPerMinute;
        }

        public override string getDisplayName() {
        return "Rhythm Game";
        }

        public override string getSceneName()  {
            return "RhythmGameScene";
        }

        public override MiniGameType getMiniGameType() {
            return MiniGameType.freeForAll;
        }

        void Awake() {
            if(_instance != null && _instance != this) {
                Destroy(this.gameObject);
            } else {
                _instance = this;    
            }
            if(songIndex < 0) {
                songIndex = UnityEngine.Random.Range(0, songs.Count);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            player1.GetComponent<Player>().isAI = PlayerPrefs.GetString("Player1_AI").Equals("True");
            player2.GetComponent<Player>().isAI = true;//PlayerPrefs.GetString("Player2_AI").Equals("True");
            player3.GetComponent<Player>().isAI = true;//PlayerPrefs.GetString("Player3_AI").Equals("True");
            player4.GetComponent<Player>().isAI = true;//PlayerPrefs.GetString("Player4_AI").Equals("True"); 

            var playerInputs = new List<PlayerInput>();
            if(!player1.GetComponent<Player>().isAI) {
                playerInputs.Add(player1.GetComponent<PlayerInput>());
            }
            if(!player2.GetComponent<Player>().isAI) {
                playerInputs.Add(player2.GetComponent<PlayerInput>());
            }
            if(!player3.GetComponent<Player>().isAI) {
                playerInputs.Add(player3.GetComponent<PlayerInput>());
            }
            if(!player4.GetComponent<Player>().isAI) {
                playerInputs.Add(player4.GetComponent<PlayerInput>());
            }
            
            InputManager.Instance.AssignPlayerInput(playerInputs);

            //LoadingManager.Instance.LoadMiniGame(getMiniGameType());
            
            
            _instance = this;
            // DANCE
            beatsPerMinute = songs[songIndex].GetComponent<Song>().beatsPerMinute;
        }

        // Update is called once per frame
        void Update()
        {
            if(!startPlaying) {
                if(Input.anyKeyDown) {
                    
                    startPlaying = true;
                    noteSystem.setHasStarted();
                    songs[songIndex].GetComponent<AudioSource>().Play();
                    //DANCE
                    GameEventSystem.current.StartDance();
                }
            }

            if(!songs[songIndex].GetComponent<AudioSource>().isPlaying && startPlaying) {

                var scores = new List<(int, int)>();
                scores.Add((1, player1.GetComponent<Score>().score));
                scores.Add((2, player2.GetComponent<Score>().score));
                scores.Add((3, player3.GetComponent<Score>().score));
                scores.Add((4, player4.GetComponent<Score>().score));

                scores.Sort(delegate ((int, int) p1, (int, int) p2) 
                {
                    return p1.Item2.CompareTo(p2.Item2);
                });

                // TODO check double places
                List<List<int>> places = new List<List<int>>();
                for(int i=0;i<4;++i) {
                    places[i] = new List<int>();
                }
                places[0].Add(scores[3].Item1);
                
                int lastPlace = 0;
                for(int i=2;i >= 0; --i) {
                    if(scores[i].Item1 < scores[i+1].Item1) {
                        lastPlace++;
                    }
                    places[lastPlace].Add(i);
                }

                MiniGameFinished(
                    firstPlace: places[0].ToArray(), 
                    secondPlace: places[1].ToArray(),
                    thirdPlace: places[2].ToArray(),
                    fourthPlace: places[3].ToArray()
                );
            }
        }

        public GameObject getSong() {
            return songs[songIndex];
        }

        //DANCE
        void DanceEvent()
        {
            GameEventSystem.current.Hit();
            
        }

        void BeatEvent()
        {
            GameEventSystem.current.Beat();
        }
    }
}