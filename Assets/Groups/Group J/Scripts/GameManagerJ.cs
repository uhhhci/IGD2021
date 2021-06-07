using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerJ : MonoBehaviour
{
    // Start is called before the first frame update
    public int deathCount1 = 0;
    public int deathCount2 = 0;
    public Text team1DeathCount;
    public Text team2DeathCount;
    public GameObject arm;
    private float counter = 0;

    void Start()
    {
        StartCoroutine(MotorChange(arm, counter));
    }

    IEnumerator MotorChange(GameObject arm, float counter)
    {
        while (true)
        {
            arm.GetComponent<HingeJoint>().motor = new JointMotor() { targetVelocity = 100 + counter, force = 100000 };
            counter += 5;
            yield return new WaitForSeconds(3);
        }
    }

    public void UpdateDeath(bool isTeam1)
    {
        if (isTeam1) 
        {
            deathCount1++;
            team1DeathCount.text = "Deaths: " + deathCount1;
        }
        else
        {
            deathCount2++;
            team2DeathCount.text = "Deaths: " + deathCount2;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
