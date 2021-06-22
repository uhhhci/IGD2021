using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{    
    public GameObject trap;


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(trap, new Vector3(2,2,-10), Quaternion.identity);
    }

    public GameObject spawnTrap(Vector3 location)
    {
        return Instantiate(trap, location, Quaternion.identity);
    }
}
