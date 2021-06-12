using System;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP {
    public class Player : MonoBehaviour
    {
        private class NoteInfo {
            public NoteInfo(Note note) {
                this.note = note;
                hitQuality = note.hitQuality;
                hit = false;
                missed = false;
            }
            public Note note;
            public HitQuality hitQuality;
            public Boolean hit;
            public Boolean missed;
        }

        private bool missed;

        private Dictionary<KeyType, NoteInfo> notes = new Dictionary<KeyType, NoteInfo>();

        void Awake() {
            
        }
        // Start is called before the first frame update
        void Start()
        {
            KeyPressHandler.instance.registerPlayer(this.gameObject);

            foreach(var keyType in Enum.GetValues(typeof(KeyType)))  {
                notes.Add((KeyType)keyType, null);
            }
            missed = false;
        }

        public void addNote(Note note) {
            if(notes[note.key] != null) return;

            notes[note.key] = new NoteInfo(note);
        }

        public void removeNote(Note note) {
            
        }

        public void keyPressed(KeyType keyType) {
            
            if(notes[keyType] == null) {
                missed = true;
                return;
            }
            if(!notes[keyType].hit) {
                notes[keyType].hit = true;
                notes[keyType].hitQuality = notes[keyType].note.hitQuality;
            }
        }
    }
}