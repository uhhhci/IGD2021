using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP {
    
    public class Note : MonoBehaviour
    {

        private bool collision;

        public KeyType key;

        public HitQuality hitQuality = HitQuality.NULL;

        Collider2D collisionObject;

        public float tempo;

        public bool bad = false;
        public bool special = false;

        private bool triedSwapToBad = false;

        void Awake() 
        {
                
        }

        // Start is called before the first frame update
        void Start()
        {
            switch(key) {
            case KeyType.UP:      //up arrow
                transform.localEulerAngles = new Vector3(0f, 0f, -90f);
                transform.localPosition += new Vector3(0f, 80f , 0f);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f);
                break;
            case KeyType.DOWN:      //down arrow
                transform.localEulerAngles = new Vector3(0f, 0f, 90f);
                transform.localPosition += new Vector3(0f, -40 , 0f);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
                break;
            case KeyType.LEFT:     //left arrow
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                transform.localPosition += new Vector3(0f, 40f , 0f);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
                break;
            case KeyType.RIGHT:        //right arrow
                transform.localPosition += new Vector3(0f, 0f , 0f);
                transform.localEulerAngles = new Vector3(0f, 0f, 180f);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.624f, 0f);
                break;
            default:
                break;
            }
            if(gameObject.GetComponent<Note>().special) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            }
            else if(gameObject.GetComponent<Note>().bad) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(GameManager.instance.startPlaying) {
                transform.localPosition -= new Vector3(Time.deltaTime*tempo, 0f, 0f);
                updateHitQuality();
            }
            if(transform.localPosition.x > 55 && transform.localPosition.x < 65 && !special && !bad && !triedSwapToBad) {
                if(UnityEngine.Random.Range(0f,1f) < 0.2) { 
                    return;
                }
                if(UnityEngine.Random.Range(0f, 1f) < 0.08f) {
                    bad = true;
                    gameObject.GetComponent<SpriteRenderer>().color  = new Color(0f, 0f, 0f);
                }
                triedSwapToBad = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "activator") {
                collisionObject = other;
                
                KeyPressHandler.instance.registerNote(this);
                collision = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if(other.tag == "activator") {
                KeyPressHandler.instance.deregisterNote(this);
                
                Destroy(gameObject, 0.05f);
            }
        }

        private void updateHitQuality() {
            if(!collision) {
                hitQuality = HitQuality.NULL;
                return;
            }

            float x = Mathf.Abs(transform.position.x - collisionObject.transform.position.x);
            if(x > 0.03) {
                hitQuality = HitQuality.NORMAL;
            } else if (x > 0.02) {
                hitQuality = HitQuality.GOOD;
            } else if (x <= 0.01) {
                hitQuality = HitQuality.PERFECT;
            } 
        }
    }
}