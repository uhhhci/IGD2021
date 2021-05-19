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
        }

        // Update is called once per frame
        void Update()
        {
            updateHitQuality();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "activator") {
                Debug.Log("OnTriggerEnter");
                collisionObject = other;
                
                KeyPressHandler.registerNote(this);
                collision = true;

                //Debug.Log(transform.position.x);
                //Debug.Log(collisionObject.transform.position.x);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if(other.tag == "activator") {
                //Debug.Log("OnTriggerExit");
                KeyPressHandler.deregisterNote(this);
                
                Destroy(gameObject, 0.2f);
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