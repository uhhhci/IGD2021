using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyBomb",1);
    }

    // Update is called once per frame
    void update()
    {
        
    }
    void destroyBomb()
    {
        Collider[] collidersToHit = Physics.OverlapSphere(transform.position, 3f);
        foreach(Collider nearbyPlayer in collidersToHit)
        {
            Rigidbody rb = nearbyPlayer.GetComponent<Rigidbody>();
            if (rb != null && nearbyPlayer.tag == "Player")
            {
                Debug.Log("Bombentreffer");
                Debug.Log(nearbyPlayer.gameObject);
                nearbyPlayer.gameObject.SendMessage("takeDamage");
            }
            
        }
        Instantiate(explosion,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
