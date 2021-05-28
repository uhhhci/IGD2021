using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 cameraOffset;
    public float cameraSpeed = 5.0f;
    private Vector3 startingPos; // position where a movement was started
    private Vector3 targetPos;
    private double flyingTime;
    private double distance;

    public float deadzone = 0.1f;

    public Transform diceArea;
    public Transform[] players;
    public Transform goldenBrick;
    public Transform itemThief;


    private Transform target;
    private bool movementDone;

    public void moveToDice() {
        setNewTarget(diceArea);
    }

    public void moveToPlayer(int player) {
        setNewTarget(players[player]);
    }

    public void moveToGoldenBrick() {
        setNewTarget(goldenBrick);
    }

    public void followItemThief() {
        setNewTarget(itemThief);
    }

    private void setNewTarget(Transform newTarget) {
        target = newTarget;
        startingPos = transform.position;
        flyingTime = 0.0;
        distance = Vector3.Distance(startingPos, target.position + cameraOffset);
        movementDone = false;
    }

    public bool movementCompleted() {
        return movementDone;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position + cameraOffset;
        float remainingDistance = Vector3.Distance(transform.position, targetPos);
        if (remainingDistance >= deadzone) {
            flyingTime += Time.deltaTime;
            transform.position = Vector3.Lerp (startingPos, targetPos, (float) (cameraSpeed * flyingTime / distance));
            transform.LookAt(target.position);
        }
        else {
            movementDone = true;
        }
    }
}
