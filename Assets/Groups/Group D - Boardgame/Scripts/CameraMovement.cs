using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 cameraOffset;
    public float cameraSpeed = 5.0f;
    public float deadzone = 0.1f;

    public Transform diceArea;
    public Transform[] players;
    public Transform goldenBrick;


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

    private void setNewTarget(Transform newTarget) {
        target = newTarget;
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
            transform.position = Vector3.Lerp (transform.position, targetPos, cameraSpeed * Time.deltaTime);
            transform.LookAt(target.position);
        }
        else {
            movementDone = true;
        }
    }
}
