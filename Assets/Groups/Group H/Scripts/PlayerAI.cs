using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{

    public MinifigControllerH controller;

    public float viewingDistance = 2f;
    public float dangerViewingDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // if (Playerprefs.GetString("Player1_AI").Equals("True"))
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
            // if cars or bombs are near, go away from them
            GameObject car = FindCar();
            GameObject bomb = FindBomb();
            if (car != null && bomb != null)
            {
                Vector3 badPlace = (car.transform.position + bomb.transform.position) / 2;
                MoveAwayFrom(badPlace);
                yield return GetRandomWaitingTime();
                break;
            }
            else if (car != null)
            {
                Vector3 badPlace = car.transform.position;
                MoveAwayFrom(badPlace);
                yield return GetRandomWaitingTime();
                break;
            }
            else if (bomb != null)
            {
                Vector3 badPlace = bomb.transform.position;
                MoveAwayFrom(badPlace);
                yield return GetRandomWaitingTime();
                break;
            }

            // if a burger is close, go colllect it
            GameObject burger = FindBurger();
            if (burger != null)
            {
                MoveTo(burger.transform.position);
                yield return GetRandomWaitingTime();
                break;
            }

            // if another player is close, go and annoy him
            GameObject otherPlayer = FindOtherPlayer();
            if (otherPlayer != null)
            {
                ObstructOtherPlayer(otherPlayer);
                yield return GetRandomWaitingTime();
                break;
            }

            // else move to random location
            MoveRandomly();

            yield return GetRandomWaitingTime();
        }
    }

    private GameObject FindCar()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, dangerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, dangerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, dangerViewingDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Vehicle")
        {
            GameObject car = hit.transform.gameObject;
            return car;
        }
        return null;
    }

    private GameObject FindBomb()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, dangerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, dangerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, dangerViewingDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Bomb")
        {
            GameObject bomb = hit.transform.gameObject;
            return bomb;
        }
        return null;
    }

    private GameObject FindBurger()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, viewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, viewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, viewingDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Burger")
        {
            GameObject bomb = hit.transform.gameObject;
            return bomb;
        }
        return null;
    }

    private GameObject FindOtherPlayer()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, viewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, viewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, viewingDistance);
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
        if (Random.value < 0.5f)
        {
            // kick other player
            Debug.Log("AI kicking");
            controller.Kick();
        }
        else
        {
            // or grab other player
            Debug.Log("AI grabbing");
            controller.Grab();
        }
    }

    private void MoveRandomly()
    {
        Vector3 destination = GetRandomDestination();
        MoveTo(destination);
    }

    private Vector3 GetRandomDestination()
    {
        int x = Random.Range(-5, 6);
        int z = Random.Range(-5, 6);
        Vector3 destination = new Vector3(x, 0.1f, z);
        return destination;
    }

    private void MoveTo(Vector3 destination)
    {
        // prevent walking out of the crossing
        float x = destination.x;
        float y = 0.1f;
        float z = destination.z;
        x = Mathf.Min(5, x);
        x = Mathf.Max(-5, x);
        z = Mathf.Min(5, z);
        z = Mathf.Max(-5, z);
        destination = new Vector3(x, y, z);

        controller.TurnTo(destination, minAngle: 45, rotationSpeedMultiplier: 100000f);
        controller.MoveTo(destination, minDistance: 0.1f, rotationSpeedMultiplier: 100000f, turnToWhileCompleting: destination);
    }

    private void MoveAwayFrom(Vector3 badPlace)
    {
        Vector3 direction = gameObject.transform.position - badPlace;
        direction.Normalize();
        Vector3 destination = gameObject.transform.position + direction;
        MoveTo(destination);
    }

    private WaitForSeconds GetRandomWaitingTime()
    {
        float waitingTime = Random.Range(5, 10) / 5;
        return new WaitForSeconds(waitingTime);
    }
}
