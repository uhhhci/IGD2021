using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditThiefControl : MonoBehaviour
{

    public Vector3 offset = new Vector3(0f, 2f, 0f);    // hovering offset from players 
    public Transform[] players;                     // transforms of all four players, in order
    public float deadzone = 0.1f;                   // distance to target position where a movement is considered to be completed
    public float speed = 4.0f;                      // how many units the thief can move per second

    private Vector3 loiterPoint; // point where the item thief will loiter when it is not used
    private bool movementDone;   // whether all animations are done
    private Vector3 startingPos; // position where a movement was started
    private Vector3 targetPos;
    private double flyingTime;
    private double distance;
    public AudioClip stealAudioClip;
    AudioSource audioSource;

    private void setNewTarget(Vector3 newTarget) {
        targetPos = newTarget;
        movementDone = false;
        startingPos = transform.position;
        flyingTime = 0.0;
        distance = Vector3.Distance(startingPos, targetPos);
    }

    public void moveToPlayer(int player) {
        setNewTarget(players[player].position + offset);
    }

    public void returnToLoiterPoint() { 
        setNewTarget(loiterPoint);
    }

    public bool movementCompleted() {
        return movementDone;
    }

    // Start is called before the first frame update
    void Start()
    {
        loiterPoint = transform.position;
        targetPos = loiterPoint;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float remainingDistance = Vector3.Distance(transform.position, targetPos);
        if (remainingDistance >= deadzone) {
            flyingTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, targetPos, (float) (speed * flyingTime / distance));
            transform.LookAt(new Vector3(targetPos.x, transform.position.y, targetPos.z));
        }
        else {
            movementDone = true;
        }
    }

    public void playStealAudio()
    {
        audioSource.PlayOneShot(stealAudioClip);
    }
}
