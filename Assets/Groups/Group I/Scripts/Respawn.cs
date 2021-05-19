using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
        

        [SerializeField] private Transform Player;
        [SerializeField] private Transform RespawnPointWSAD;
        void OnTriggerEnter(Collider other)
        {
            
             Player.transform.position = RespawnPointWSAD.transform.position;
            
        }

    
}
