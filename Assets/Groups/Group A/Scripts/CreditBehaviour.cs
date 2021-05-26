using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditBehaviour : MonoBehaviour
{
    
    Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MiddlePlattform")
        {
            rigidbody.isKinematic = true;
        }

        if(collision.gameObject.tag == "Player")
        {
            MinifigControllerWTH controller = collision.gameObject.GetComponent<MinifigControllerWTH>();
            controller.AddPoints(1);
            Destroy(this.gameObject);
        }
    }
}
