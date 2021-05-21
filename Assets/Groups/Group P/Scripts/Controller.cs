using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GroupP {
    public class Controller : MonoBehaviour
    {

        
        // Start is called before the first frame update
        void Start()
        {
            string controlScheme = GetComponent<PlayerInput>().defaultControlScheme;
            GetComponent<PlayerInput>().SwitchCurrentControlScheme(controlScheme, Keyboard.current);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnEastPress()
        {
            print("OnEastPress");
        }

        private void OnWestPress() {
            Debug.Log("OnWestPress");
        }


        private void  OnUpPress() {
            KeyPressHandler.instance.keyPressed(gameObject, KeyType.UP);
        }

        private void OnDownPress() {
            KeyPressHandler.instance.keyPressed(gameObject, KeyType.DOWN);
        }

        private void OnLeftPress() {
            KeyPressHandler.instance.keyPressed(gameObject, KeyType.LEFT);
        }

        private void OnRightPress()  {
            KeyPressHandler.instance.keyPressed(gameObject, KeyType.RIGHT);
        }


        //TODO handle keypresses -> send to keypresshandler
    }
}