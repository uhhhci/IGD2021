using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool isPickedUp = false;

    public Vector3 posOffset;
    public Vector3 rotOffset;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isPickedUp){
            transform.Rotate(new Vector3(0f,2.0f,0f) , Space.World);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObj = collision.gameObject;
        if(!isPickedUp && gameObj.tag=="Player" && !gameObj.GetComponent<OurMinifigController>().hasItem){
            isPickedUp = true;
            gameObj.GetComponent<OurMinifigController>().hasItem = true;
            var tree = new List<int>(){0,1,0,1,0,0,0,0,0,0,2,0,0,1,0,0,2};
            Transform child = gameObj.transform;
            foreach (var subtree in tree)
            {
                child = child.GetChild(subtree);
            }
            transform.SetParent(child);
            transform.localPosition = posOffset;
            transform.localRotation = Quaternion.Euler(rotOffset);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }
}
