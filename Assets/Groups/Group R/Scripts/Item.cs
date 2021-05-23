using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool isPickedUp = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isPickedUp){
            transform.Rotate(new Vector3(0f,2.0f,0f) , Space.World);
        }
    }
}
