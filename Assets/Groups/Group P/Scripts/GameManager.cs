using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GroupP {
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager instance { get { return _instance; }}

        List<GameObject> players = new List<GameObject>();

        public AudioSource music;

        public bool startPlaying;

        public NoteSystem noteSystem;     //<-- Tutorial: BeatScroller theBS (theBS === noteSystem)

        //GameObject player1 = GameObject.Find("Player Minifig WASD");
        //GameObject player2 = GameObject.Find("Player Minifig ZGHJ");
        //GameObject player3 = GameObject.Find("Player Minifig PLÖÄ");
        //GameObject player4 = GameObject.Find("Player Minifig KeyboardNum");

        // ----------------- DANCE---------------
        float beatsPerMinute;
        float sekPerBeat;
        float animOffset;
        // For the onBeat-Animation: time to accent of animation / length of animation
        //float accentpoint;
        // ---------------------------------------

        void Awake() {
            if(_instance != null && _instance != this) {
                Destroy(this.gameObject);
            } else {
                _instance = this;    
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _instance = this;
            // DANCE
            beatsPerMinute = noteSystem.beatsPerMinute;
            sekPerBeat = 60f / beatsPerMinute;
            animOffset = 0.7f;
        }

        // Update is called once per frame
        void Update()
        {
            if(!startPlaying) {
                if(Input.anyKeyDown) {
                    
                    startPlaying = true;
                    noteSystem.setHasStarted();
                    music.Play();
                    //DANCE
                    InvokeRepeating("DanceEvent", (8 + animOffset) * sekPerBeat, 8 * sekPerBeat);
                    InvokeRepeating("BeatEvent", animOffset * sekPerBeat, sekPerBeat);
                }
            }
        }

        //DANCE
        public void registerPlayer(GameObject player) {
            players.Add(player);
        }

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