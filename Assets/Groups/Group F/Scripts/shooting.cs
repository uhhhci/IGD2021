using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var newPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            Rigidbody instantiatedProjectile = Instantiate(projectile, newPos, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
