using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnJ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Item;
    public GameObject Platform;

    public float timeRemaining = 90;
    private bool timerIsRunning = false;

    private void Start()
    {

        // Starts the timer automatically
        timerIsRunning = true;
        for (int i = 0; i < 28; i++)
        {
            randomSpwanTime.Add((int)Random.Range(1, timeRemaining));
        }
    }
    List<int> randomSpwanTime = new List<int>();
    // Update is called once per frame
    void Update()
    {
      /*  if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
        
                if ((int)timeRemaining == 70 || (int)timeRemaining == 85)
                {
                    Debug.Log("Respwan");
                    SpawnObjectAtRandom();
                }
             
            }
        }
*/
 
    }
    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * (Platform.transform.position.z/2);
        Instantiate(Item, Platform.transform.position, Platform.transform.rotation);
     
    //    Gizmos.DrawWireSphere(this.transform.position, (Platform.transform.position.z / 2));
    }
}
