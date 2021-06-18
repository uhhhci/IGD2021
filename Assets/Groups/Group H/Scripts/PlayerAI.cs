using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{

    public MinifigControllerH controller;

    public float carViewingDistance = 100f;
    public float bombViewingDistance = 4f;
    public float burgerViewingDistance = 5f;
    public float playerViewingDistance = 2f;

    private State state;
    private Vector3 currentDestination;



    // States for AI player
    enum State
    {
        Idle,
        Waiting,

        MovingAwayFromDanger,
        MovingToBurger,
        MovingToPlayer,

        MovingRandomly,
    }

    // Start is called before the first frame update
    void Start()
    {
        // if (Playerprefs.GetString("Player1_AI").Equals("True"))
        // StartCoroutine(MainIteration());
        state = State.Idle;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == State.Idle || state == State.MovingRandomly)
        {
            Vector3 currentPosition = transform.position;

            // if cars or bombs are close, go away from them
            GameObject car = FindCar();
            GameObject bomb = FindBomb();

            if (car != null && bomb != null)
            {
                Vector3 badPlace = (car.transform.position + bomb.transform.position) / 2;
                MoveAwayFrom(badPlace);
            }
            else if (car != null)
            {
                Vector3 badPlace = car.transform.position;
                MoveAwayFrom(badPlace);
            }
            else if (bomb != null)
            {
                Vector3 badPlace = bomb.transform.position;
                MoveAwayFrom(badPlace);
            }

            // if a burger is close, go colllect it
            GameObject burger = FindBurger();
            if (burger != null && state != State.MovingAwayFromDanger)
            {
                state = State.MovingToBurger;
                MoveTo(burger.transform.position);
                //state = State.Idle;
            }

            // if another player is close, go and annoy him
            GameObject otherPlayer = FindOtherPlayer();
            if (otherPlayer != null && state != State.MovingAwayFromDanger && state != State.MovingToBurger)
            {
                ObstructOtherPlayer(otherPlayer);
            }

            // else move to random location
            if (state == State.Idle)
            {
                MoveRandomly();
                StartCoroutine(Wait());
            }

            if (state != State.MovingRandomly)
            {
                StartCoroutine(Wait());
            }
        }
    }

    private GameObject FindCar()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, carViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, carViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, carViewingDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Vehicle")
        {
            GameObject car = hit.transform.gameObject;
            return car;
            if ((car.transform.rotation.y / 90) % 2 == 0) // x is important lane
            {
                // if player is on car's lane
                if (car.transform.position.x + 1 < transform.position.x || car.transform.position.x - 1 > transform.position.x)
                {
                    return car;
                }
            }
            else // z is important lane
            {
                // if player is on car's lane
                if (car.transform.position.z + 1 < transform.position.z || car.transform.position.z - 1 > transform.position.z)
                {
                    return car;
                }
            }
        }
        return null;
    }

    private GameObject FindBomb()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, bombViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, bombViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, bombViewingDistance);
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

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, burgerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, burgerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, burgerViewingDistance);
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

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, playerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right, out hit, transform.rotation, playerViewingDistance) || Physics.BoxCast(transform.position, transform.localScale, transform.right * -1, out hit, transform.rotation, playerViewingDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Player")
        {
            GameObject otherPlayer = hit.transform.gameObject;
            return otherPlayer;
        }
        return null;
    }

    private void ObstructOtherPlayer(GameObject otherPlayer)
    {
        state = State.MovingToPlayer;
        controller.Follow(otherPlayer.transform, 0.5f);
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
        state = State.MovingRandomly;
        Vector3 destination = transform.position + GetRandomDirection();
        MoveTo(destination);
    }

    private Vector3 GetRandomDirection()
    {
        int x = Random.Range(-2, 2);
        int z = Random.Range(-2, 2);
        Vector3 direction = new Vector3(x, 0.1f, z);
        return direction;
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
        Debug.Log("RUN!");
        state = State.MovingAwayFromDanger;
        Vector3 direction = gameObject.transform.position - badPlace;
        direction.Normalize();
        Vector3 destination = gameObject.transform.position + direction * 3;
        MoveTo(destination);
    }

    private IEnumerator Wait()
    {
        float waitingTime = Random.Range(10, 20) / 10;
        if (state == State.MovingRandomly)
        {
            //waitingTime = Random.Range(10, 15) / 10;
        }
        yield return new WaitForSeconds(waitingTime);
        state = State.Idle;
    }
}
