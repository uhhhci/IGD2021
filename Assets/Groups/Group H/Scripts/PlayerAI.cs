using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{

    public MinifigControllerH controller;

    public float viewingDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MainIteration());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator MainIteration()
    {
        while (true)
        {
            // TODO: find cars and move away from cars
            // TODO: find bombs and move away from bombs
            // TODO: find burgers and move to from burgers

            GameObject otherPlayer = FindOtherPlayer();
            if (otherPlayer != null)
            {
                ObstructOtherPlayer(otherPlayer);
            }
            else
            {
                MoveRandomly();
            }
            yield return GetRandomWaitingTime();
        }
    }

    private GameObject FindOtherPlayer()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, viewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, viewingDistance) || Physics.BoxCast(transform.position, transform.localScale, -transform.right, out hit, transform.rotation, viewingDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Player")
        {
            GameObject otherPlayer = hit.transform.gameObject;
            return otherPlayer;
        }
        return null;
    }

    private void ObstructOtherPlayer(GameObject otherPlayer)
    {
        MoveTo(otherPlayer.transform.position);
        // TODO: or grab other player
        controller.Kick();
    }

    private void MoveRandomly()
    {
        Vector3 destination = GetRandomDestination();
        MoveTo(destination);
    }

    private Vector3 GetRandomDestination()
    {
        int x = Random.Range(-5, 5);
        int z = Random.Range(-5, 5);
        Vector3 destination = new Vector3(x, 0.1f, z);
        return destination;
    }

    private void MoveTo(Vector3 destination)
    {
        controller.TurnTo(destination, minAngle: 45, rotationSpeedMultiplier: 100000f);
        controller.MoveTo(destination, minDistance: 0.1f, rotationSpeedMultiplier: 100000f, turnToWhileCompleting: destination);
    }

    private WaitForSeconds GetRandomWaitingTime()
    {
        float waitingTime = Random.Range(5, 10) / 3;
        return new WaitForSeconds(waitingTime);
    }
}
