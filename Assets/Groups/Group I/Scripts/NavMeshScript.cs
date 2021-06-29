using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour

{
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent Player4 = GetComponent<NavMeshAgent>();
        Player4.destination = goal.position;


    }

}
