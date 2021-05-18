using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    private Vector3 targetPosition;
    void Start() 
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }

    public void MoveForward(float targetDistance)
    {
        targetPosition = targetPosition + new Vector3(-targetDistance,0,0);
    } 
}
