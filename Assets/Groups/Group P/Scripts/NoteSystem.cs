using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP {

    public class NoteSystem : MonoBehaviour
    {
        [System.Serializable]
        public class NoteEntry {

            public float beat;
            //public Note note;

            public List<KeyType> keys;

            public Animation animation;
        }

        public UnityEngine.GameObject notePrefab;

        public float beatsPerMinute;
        private float deltaBeatS;
        private float lastBeat;
        private float tempo;

        private int counter;

        private bool hasStarted;

        public Queue<NoteEntry> noteQueue;
        public Queue<UnityEngine.GameObject> activated;

        public void setHasStarted() {
            hasStarted = true;
        }
        void Start()
        {
            tempo = beatsPerMinute;// / 60f;
            noteQueue = new Queue<NoteEntry>();
            activated = new Queue<UnityEngine.GameObject>();

            lastBeat = 0;
            deltaBeatS = 1 / tempo;
            counter = 0;

            for(int i=0;i<100;++i) {
                List<KeyType> keys = new List<KeyType>(new KeyType[] {KeyType.UP, KeyType.DOWN, KeyType.LEFT, KeyType.RIGHT});
                
                
                int n = UnityEngine.Random.Range(1, 3);
                for(int j=0;j<n;++j) {
                    int index = UnityEngine.Random.Range(0, keys.Count);
                    activated.Enqueue(spawnNote(i*tempo * 2 + 0.5f*tempo, keys[index]));
                    keys.RemoveAt(index);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(hasStarted) {
                transform.localPosition -= Vector3.Scale( transform.localScale , new Vector3(2*Time.deltaTime*tempo, 0f, 0f));
            }
            float now = Time.time;
        
            if (now - lastBeat > deltaBeatS || now == 0) {
                
                float offset = now - lastBeat - deltaBeatS;
                
                if(counter % 4 == 0) {
                    //spawnNote(tempo * 8 - offset);
                }

                lastBeat = now - offset;

                counter += 1;
            }
        }

        UnityEngine.GameObject spawnNote(float position, KeyType key) {
            UnityEngine.GameObject obj = Instantiate(notePrefab);
            obj.SetActive(true);
            
            UnityEngine.Random.Range(0, 4);
            obj.GetComponent<Note>().key = key;
            
            obj.transform.parent = gameObject.transform;
            obj.transform.localScale = notePrefab.transform.localScale;
            obj.transform.localPosition = new Vector3(position, 0f, 0f);
            
            activated.Enqueue(obj);

            return obj;
        }
    }
}