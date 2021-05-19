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
            public bool hasHitLastNote;
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
            playerStat.hasHitLastNote = false;
            playerStats.Add(playerStat);
            Debug.Log(playerStats.Count);
        }

        public void registerNote(Note note) {
            currentNotes.Add(note);
        }

        public void deregisterNote(Note note) {
            //TODO call MissedHit() for players who havent hit the note
            foreach(var playerStat in playerStats) {
                if(!playerStat.hasHitLastNote) {
                    playerStat.player.GetComponent<Score>().Missed();
                }
                playerStat.hasHitLastNote = false;
            }
            currentNotes.Remove(note);
        }

        public void keyPressed(GameObject currentPlayer, KeyType keyType) {
            
            foreach (var note in currentNotes)
            {

                foreach (var playerStat in playerStats)
                {
                    
                   if(playerStat.player.name.Equals(currentPlayer.name)) {
                    if(!playerStat.hasHitLastNote) {
                        playerStat.player.GetComponent<Score>().Hit(note.hitQuality);
                        playerStat.hasHitLastNote = true;
                    }
                    
                   }
                   
                }
            }
        }
    }
}