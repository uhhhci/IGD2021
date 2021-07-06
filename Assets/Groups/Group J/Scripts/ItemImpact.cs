using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemImpact : MonoBehaviour
{
    private bool collided;

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("collison fireball");
        if (other.gameObject.tag == "Player")
        {
 
            Debug.Log("Hit target");
            other.gameObject.GetComponent<AIController>().AddImpact(this.transform.forward * 45);
            collided = true;
            Destroy(gameObject);
        }
    }
    }
