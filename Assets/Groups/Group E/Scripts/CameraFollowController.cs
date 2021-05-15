﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10f;
    public float lookSpeed = 10f;


    private void LookAtTarget()
    {
        Vector3 lookDirection = objectToFollow.position + new Vector3(0, 0, 0.5f) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);

    }

    private void MoveToTarget()
    {
        Vector3 targetPos = objectToFollow.position 
            + objectToFollow.forward * offset.z +
            objectToFollow.right * offset.x +
            objectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
