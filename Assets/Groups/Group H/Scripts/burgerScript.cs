using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerScript : MonoBehaviour
{
    public GameObject buff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision player)
    {
        Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
            if (rb != null && player.gameObject.tag == "Player")
        {
            Debug.Log("NomNomDone");
            player.gameObject.GetComponent<Health>().SendMessage("increaseHealth");
            Instantiate(buff,transform.position,Quaternion.Euler(-90,0,0));
            Destroy(gameObject);
        }

    }
}
