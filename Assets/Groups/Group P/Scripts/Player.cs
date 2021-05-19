using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroupP {
public class Player : MonoBehaviour
{

    void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.registerPlayer(this.gameObject);
        KeyPressHandler.registerPlayer(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}