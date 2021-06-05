using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GroupP {
    public class Controller : MonoBehaviour
    {

        public float waitTimeAfterBadHit = 4.0f;

        private float remainingWaitTime = 0f;

        public void badHit() {
            remainingWaitTime = waitTimeAfterBadHit;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
            GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
        }

        // Update is called once per frame
        void Update()
        {
            if(remainingWaitTime > 0) {
                remainingWaitTime -= Time.deltaTime;
            }
        }

        private void OnEastPress()
        {
            print("OnEastPress");
        }

        private void OnWestPress() {
            Debug.Log("OnWestPress");
        }


        private void  OnUpPress() {
            sendKeyPressToKeyPressHandler(KeyType.UP);
        }

        private void OnDownPress() {
            sendKeyPressToKeyPressHandler(KeyType.DOWN);
        }

        private void OnLeftPress() {
            sendKeyPressToKeyPressHandler(KeyType.LEFT);
        }

        private void OnRightPress()  {
            sendKeyPressToKeyPressHandler(KeyType.RIGHT);
        }

        private void sendKeyPressToKeyPressHandler(KeyType type) {
            if(remainingWaitTime > 0f) { return; }
            KeyPressHandler.instance.keyPressed(gameObject, type);
        }

        //TODO handle keypresses -> send to keypresshandler
    }
}