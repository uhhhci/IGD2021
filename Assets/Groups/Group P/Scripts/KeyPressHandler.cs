using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP {
    public class KeyPressHandler : MonoBehaviour
    {

        private static KeyPressHandler _instance;
        public static KeyPressHandler instance { get { return _instance; }}
        
        private class PlayerStat {
            public GameObject player;
            public List<bool> hasHitNotes;
        }

        List<PlayerStat> playerStats = new List<PlayerStat>();

        List<Note> currentNotes = new List<Note>();

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
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void registerPlayer(GameObject player) {
            PlayerStat playerStat = new PlayerStat();
            playerStat.player = player;
            playerStat.hasHitNotes = new List<bool>();
            playerStats.Add(playerStat);
            Debug.Log(playerStats.Count);
        }

        public void registerNote(Note note) {
            foreach(var playerStat in playerStats) {
                playerStat.hasHitNotes.Add(false);
            }
            currentNotes.Add(note);
        }

        public void deregisterNote(Note note) {
            int index = currentNotes.IndexOf(note);
            //TODO call MissedHit() for players who havent hit the note
            foreach(var playerStat in playerStats) {
                if(!playerStat.hasHitNotes[index] && !note.bad) {
                    playerStat.player.GetComponent<Score>().Missed();
                }
                playerStat.hasHitNotes.RemoveAt(index);
            }
            currentNotes.Remove(note);
        }

        public void keyPressed(GameObject currentPlayer, KeyType keyType) {
            
            foreach (var note in currentNotes)
            {
                int index = currentNotes.IndexOf(note);
                foreach (var playerStat in playerStats)
                {
                    
                   if(playerStat.player.name.Equals(currentPlayer.name)) {
                        if(!playerStat.hasHitNotes[index]) {
                            if(keyType == note.key) {
                                if(note.bad == true) {
                                    playerStat.player.GetComponent<Score>().BadHit();
                                } else if (note.special) {
                                    playerStat.player.GetComponent<Score>().SpecialHit(note.hitQuality);
                                }
                                else {
                                    playerStat.player.GetComponent<Score>().Hit(note.hitQuality);
                                }

                                playerStat.hasHitNotes[index] = true;
                            }
                        }
                   }
                }
            }
        }
    }
}