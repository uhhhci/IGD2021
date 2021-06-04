using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCar.bombCount +=1;
        Invoke("destroyBomb",2);
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
        SpawnCar.bombCount -= 1;
        
        Destroy(gameObject);
    }
}
