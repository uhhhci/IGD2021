using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP {
    public class KeyPressHandler : MonoBehaviour
    {
        private class PlayerStat {
            public GameObject player;
            public bool hasHitLastNote;
        }

        static List<PlayerStat> playerStats = new List<PlayerStat>();

        static List<Note> currentNotes = new List<Note>();
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public static void registerPlayer(GameObject player) {
            PlayerStat playerStat = new PlayerStat();
            playerStat.player = player;
            playerStat.hasHitLastNote = false;
            playerStats.Add(playerStat);
Debug.Log(playerStats.Count);
        }

        public static void registerNote(Note note) {
            currentNotes.Add(note);
        }

        public static void deregisterNote(Note note) {
            //TODO call MissedHit() for players who havent hit the note
            foreach(var playerStat in playerStats) {
                if(!playerStat.hasHitLastNote) {
                    playerStat.player.GetComponent<Score>().Missed();
                }
                playerStat.hasHitLastNote = false;
            }
            currentNotes.Remove(note);
        }

        static public void keyPressed(GameObject currentPlayer, KeyType keyType) {
            
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