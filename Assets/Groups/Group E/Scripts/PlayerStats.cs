using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int rounds;
    public Text textRounds;
    public Text textPosition;
    public int CurrentZone;
    public Transform lastZone;
    public int position;
    private static int WAYPOINT_VALUE = 100;
    private static int LAP_VALUE = 10000;
    // Start is called before the first frame update
    void Start()
    {
        rounds = 1;
    }

    public void CountRound()
    {
        rounds += 1;
        if(rounds < 4)
        {
            textRounds.text = "Round: " + rounds + "/3";
        } else
        {
            textRounds.text = "You finished!";
        }
    }

    public float GetDistance()
    {
        return (transform.position - lastZone.position).magnitude + CurrentZone * WAYPOINT_VALUE + rounds * LAP_VALUE;
    }

    public int GetKartPosition(List<Transform> carTransformList)
    {
        float distance = GetDistance();
        int position = 1;
        foreach(Transform car in carTransformList)
        {
            PlayerStats thePlayer = car.GetComponent<PlayerStats>();
            if (thePlayer.GetDistance() > distance)
            {
                position++;
            }
        }
        //Debug.Log("Position: " + position);
        textPosition.text = "Position: " + position + "/4";
        return position;
    }
}
