﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    public GameManagerK gameManager;
    public CountdownTimer timer;
    private GameObject currentBridge;
    private Vector3 craneTargetPosition;
    private Vector3 craneStartPosition;
    private Quaternion craneStartRotation;
    private Quaternion craneTargetRotation;
    private Vector3 bridgeTargetPosition;
    private Vector3 bridgeStartPosition;
    private float movementDistance = 2.5f;
    private float progress = 0.0f;
    private bool targetReached = true;

    void Start()
    {
        craneTargetPosition = transform.position;
    }

    void Update()
    {
        if (!targetReached)
        {
            transform.position = Vector3.Lerp(craneStartPosition, craneTargetPosition, progress);
            transform.rotation = Quaternion.Slerp(craneStartRotation, craneTargetRotation, progress);
            if (progress >= 1.0f)
            {
                targetReached = true;           
            }
        }

        if (currentBridge != null)
        {
            currentBridge.transform.position = Vector3.Lerp(bridgeStartPosition, bridgeTargetPosition, progress);

            if (progress >= 1.0f)
            {
                currentBridge = null;
                gameManager.BridgeInPosition();
            }
        }
        gameObject.transform.Find("TimeDisplay").rotation = Quaternion.Euler(0, -90, 0);
        progress += (Time.deltaTime * 0.5f);
    }

    private void ResetMarkers() 
    {
        targetReached = false;
        progress = 0.0f;
    }

    public void MoveIntoScene(bool leftCrane, GameObject bridge)
    {
        timer.ResetTimer();
        currentBridge = bridge;
        int direction = leftCrane? 1 : -1;

        Vector3 currentBridgePos = currentBridge.transform.position;
        currentBridge.transform.position = new Vector3(currentBridgePos.x, currentBridgePos.y, currentBridgePos.z - direction * movementDistance);
        currentBridgePos = currentBridge.transform.position;
        bridgeTargetPosition = new Vector3(currentBridgePos.x, currentBridgePos.y, currentBridgePos.z + direction * movementDistance);

        transform.position = new Vector3(currentBridgePos.x, currentBridgePos.y + currentBridge.transform.localScale.y/2, currentBridgePos.z); 
        craneTargetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + direction * movementDistance);

        craneStartPosition = transform.position;
        craneStartRotation = transform.rotation;
        craneTargetRotation = transform.rotation;
        bridgeStartPosition = currentBridge.transform.position;
        ResetMarkers();
    }

    /**
    Should not be used before the crane has been moved into the scene for the first time
    **/
    public void MoveOutOfScene(bool leftCrane)
    {
        int direction = leftCrane? -1 : 1;
        craneTargetPosition = new Vector3(transform.position.x, transform.position.y, craneTargetPosition.z + direction * movementDistance);
        craneStartPosition = transform.position;
        craneStartRotation = transform.rotation;
        craneTargetRotation = Quaternion.identity;
        ResetMarkers();
    }

}
