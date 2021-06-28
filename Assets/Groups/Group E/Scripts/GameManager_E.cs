using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager_E : MonoBehaviour
{
    int totalWinners = 0;
    public List<Transform> carTransformList;
    public List<Transform> carPositionList;
    public Transform Checkpoints;

    public int firstPlace;
    public int secondPlace;
    public int thirdPlace;
    public int fourthPlace;

    public static GameManager_E Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void countRound(Transform player)
    {
        PlayerStats thePlayer = player.GetComponent<PlayerStats>();
        thePlayer.CountRound();

        this.setPlaces(thePlayer);
        //player.GetComponent<CarController>().enabled = false;  
    }

    // Sets Place if there are not yet set
    private void setPlaces(PlayerStats thePlayer)
    {
        if (thePlayer.rounds == 4)
        {
            if (firstPlace == 0)
            {
                firstPlace = thePlayer.playerNumber;
                totalWinners += 1;
                this.startCounter();
            } else if(secondPlace == 0)
            {
                secondPlace = thePlayer.playerNumber;
                totalWinners += 1;
            } else if(thirdPlace == 0)
            {
                thirdPlace = thePlayer.playerNumber;
                totalWinners += 1;
            } else if(fourthPlace == 0)
            {
                fourthPlace = thePlayer.playerNumber;
            }
        }
    }

    private void startCounter()
    {
        //Debug.Log("Game finished!");
        TimerCountdown.Instance.startTimer();
    }

    public Transform GetPlayerByPosition(int position)
    {
        // Snapshot of car transform list
        List<Transform> carList = new List<Transform>(carTransformList);

        foreach (Transform car in carList)
        {
            PlayerStats thePlayer = car.GetComponent<PlayerStats>();

            if(thePlayer.GetKartPosition(carList) == position)
            {
                return car;
            }
        }
        
        // Should not be reachable;
        throw new System.Exception("Position Error: The position " + position + " does not exist.");
    }

    public int GetPositionByPlayer(Transform carTransform)
    {
        // Snapshot of car transform list
        List<Transform> carList = new List<Transform>(carTransformList);

        PlayerStats thePlayer = carTransform.GetComponent<PlayerStats>();
        try
        {
            return thePlayer.GetKartPosition(carList);
        }
        catch (System.Exception)
        {
            throw new System.Exception("Position Error: Could not find position of player: " + carTransform.ToString());
        }

    }

    private void Start()
    {
        totalWinners = 0;
        carPositionList = new List<Transform>();
        //InitializeAIPlayer(carTransformList[0]);
        //InitializeAIPlayer(carTransformList[1]);
        //InitializeAIPlayer(carTransformList[2]);
        InitializeAIPlayer(carTransformList[3]);
        

    }

    public void CreateAI()
    {
        if (PlayerPrefs.GetString("Player1_AI").Equals("True"))
        {
            InitializeAIPlayer(carTransformList[0]);
        }
        if (PlayerPrefs.GetString("Player2_AI").Equals("True"))
        {
            InitializeAIPlayer(carTransformList[1]);
        }
        if (PlayerPrefs.GetString("Player3_AI").Equals("True"))
        {
            InitializeAIPlayer(carTransformList[2]);
        }
        if (PlayerPrefs.GetString("Player4_AI").Equals("True"))
        {
            InitializeAIPlayer(carTransformList[3]);
        }
    }

    public void finishGame()
    {
         KartRacingGame.Instance.finishGame();
    }

    private void Update()
    {
        foreach (Transform car in carTransformList)
        {
            PlayerStats thePlayer = car.GetComponent<PlayerStats>();
            thePlayer.GetKartPosition(carTransformList);

            // some error
            //Debug.Log(thePlayer.GetKartPosition(carTransformList));
            //carPositionList[(thePlayer.GetKartPosition(carTransformList) - 1)] = car;
        }

        //finish game if the players end all rounds
        if(totalWinners == 4)
        {
            this.finishGame();
        }
    }

    private void InitializeAIPlayer(Transform car)
    {
        NavMeshAgent agent = car.gameObject.AddComponent(typeof(NavMeshAgent)) as NavMeshAgent;
        agent.speed = 20;
        agent.acceleration = 15;
        agent.stoppingDistance = 10;

        NavAgentScript_E agentScript = car.gameObject.AddComponent(typeof(NavAgentScript_E)) as NavAgentScript_E;
        agentScript.Checkpoints = Checkpoints;
    }
}
