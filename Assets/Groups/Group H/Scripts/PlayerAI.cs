using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{

    public MinifigControllerH controller;

    public int ownID = 0;

    public float playerViewingDistance = 1f;

    private State state;
    private Vector3 currentDestination;
    private float prefferedDistanceFromCar = 2.5f;
    private bool[,] safePlaces = new bool[11, 11];


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
        if (!PlayerPrefs.GetString("Player" + ownID + "_AI").Equals("True"))
        {
            // Destroy(this);
        }
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        cleanSafePlaces();
        GameObject car = FindCar();
        GameObject bomb = FindBomb();

        if (state == State.Idle)
        {
            // if cars or bombs are close, go away from them
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
            if (otherPlayer != null && state != State.MovingAwayFromDanger && state != State.MovingToBurger && state != State.MovingRandomly)
            {
                ObstructOtherPlayer(otherPlayer);
            }

            // else move to random location
            if (state == State.Idle)
            {
                MoveRandomly();
            }

            // wait to start next action
            StartCoroutine(Wait());
        }
    }

    private void cleanSafePlaces()
    {
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                safePlaces[i, j] = true;
            }
        }
    }

    private void registerDangerousPlace(int x, int z)
    {
        int i = x + 5;
        int j = z + 5;
        safePlaces[i, j] = false;
    }

    private bool isSafePlace(int x, int z)
    {
        int i = x + 5;
        int j = z + 5;
        return safePlaces[i, j];
    }

    private GameObject FindCar()
    {
        GameObject[] sceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        List<GameObject> result = new List<GameObject>();
        GameObject car = null;
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            if (sceneObjects[i].tag == "Vehicle")
            {
                car = sceneObjects[i];
                Debug.Log("Car Found");
            }
        }
        if (car != null && ((car.transform.rotation.y / 90) % 2) == 0) // x is important lane
        {
            int x_car = (int)car.transform.position.x;
            for (int x = Mathf.Max(0, x_car - 1); x <= Mathf.Min(10, x_car + 1); x++)
            {
                for (int z = 0; z < 11; z++)
                {
                    registerDangerousPlace(x, z);
                }
            }
            // if player is on car's lane
            if (car.transform.position.x + prefferedDistanceFromCar < transform.position.x || car.transform.position.x - prefferedDistanceFromCar > transform.position.x)
            {
                return car;
            }
        }
        else if (car != null && ((car.transform.rotation.y / 90) % 2) == 1) // z is important lane
        {
            int z_car = (int)car.transform.position.z;
            for (int z = Mathf.Max(0, z_car - 1); z <= Mathf.Min(10, z_car + 1); z++)
            {
                for (int x = 0; x < 11; x++)
                {
                    registerDangerousPlace(x, z);
                }
            }
            // if player is on car's lane
            if (car.transform.position.z + prefferedDistanceFromCar < transform.position.z || car.transform.position.z - prefferedDistanceFromCar > transform.position.z)
            {
                return car;
            }
        }
        return null;
    }

    private GameObject FindBomb()
    {
        GameObject[] sceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        List<GameObject> result = new List<GameObject>();
        GameObject bomb = null;
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            if (sceneObjects[i].tag == "Bomb")
            {
                bomb = sceneObjects[i];
                Debug.Log("Bomb Found");
            }
        }
        return bomb;
    }

    private GameObject FindBurger()
    {
        GameObject[] sceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        List<GameObject> result = new List<GameObject>();
        GameObject burger = null;
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            if (sceneObjects[i].tag == "Burger")
            {
                burger = sceneObjects[i];
                Debug.Log("Burger Found");
            }
        }
        return burger;
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
        controller.Follow(otherPlayer.transform, 0.3f);
        if (Random.Range(0, 100) < 50)
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

        int x;
        int z;
        do
        {
            x = Random.Range(-5, 5);
            z = Random.Range(-5, 5);
        }
        while (!isSafePlace(x, z));

        Vector3 destination = new Vector3(x, 0.1f, z);
        MoveTo(destination);
    }

    private Vector3 GetRandomDirection()
    {
        int x = Random.Range(-2, 2);
        int z = Random.Range(-2, 2);
        Vector3 direction = new Vector3(x, 0, z);
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
        //MoveTo(destination);
        MoveRandomly();
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
