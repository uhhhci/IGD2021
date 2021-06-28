using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{

    public GameObject projectile;
    public Transform firePoint;
    public GameObject player;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var fireball = CreateProjectile();
            fireball.transform.localRotation = player.transform.rotation;
        }    
         
    }
     GameObject CreateProjectile()
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        return projectileObj;
    }

}
