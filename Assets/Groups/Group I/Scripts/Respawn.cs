using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private MinifigController Player;
    [SerializeField] private Transform RespawnPointWSAD;
    
    void OnTriggerEnter(Collider other)
    {
        print("Respawn");
        Player.TeleportTo(RespawnPointWSAD.transform.position);
    }
}
