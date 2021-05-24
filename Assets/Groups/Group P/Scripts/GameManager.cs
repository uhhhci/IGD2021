using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GroupP {
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager instance { get { return _instance; }}

        List<GameObject> players = new List<GameObject>();

        public List<GameObject> songs = new List<GameObject>();

        public bool startPlaying;

        public int songIndex = -1;

        public NoteSystem noteSystem;     //<-- Tutorial: BeatScroller theBS (theBS === noteSystem)

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
            if(songIndex < 0) {
                songIndex = UnityEngine.Random.Range(0, songs.Count);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _instance = this;
            // DANCE
            beatsPerMinute = songs[songIndex].GetComponent<Song>().beatsPerMinute;
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
                    songs[songIndex].GetComponent<AudioSource>().Play();
                    //DANCE
                    InvokeRepeating("DanceEvent", (8 + animOffset) * sekPerBeat, 8 * sekPerBeat);
                    InvokeRepeating("BeatEvent", animOffset * sekPerBeat, sekPerBeat);
                }
            }
        }

        public GameObject getSong() {
            return songs[songIndex];
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