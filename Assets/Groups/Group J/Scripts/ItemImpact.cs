using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemImpact : MonoBehaviour
{
    private bool collided;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != ("Obstacle") && collision.gameObject.tag != ("Item") && !collided)
        {
            collided = true;
            if (collision.gameObject.tag == "Player" )
            {
                Debug.Log("Hit target");
               collision.gameObject.GetComponent<AIController>().AddImpact(this.transform.forward * 45);
            }
            Destroy(gameObject);
        } 
    }
}
