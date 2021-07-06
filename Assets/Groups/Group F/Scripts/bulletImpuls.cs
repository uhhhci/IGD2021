using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpuls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.collider.CompareTag("Player")) return;
        var rb = col.gameObject.GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(3000.0f,3000.0f,3000.0f));
        Destroy(this);
    }
}
