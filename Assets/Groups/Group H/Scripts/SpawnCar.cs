using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public List<GameObject> cars;
    public int waitingSeconds = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(carSpawn());
    }

    IEnumerator carSpawn()
    {
        while (true)
        {
            int xPos = 0;
            int zPos = 0;
            int lane = Random.Range(-2,2)*2;
            int direction = Random.Range(0, 3);
            int rotation = direction * 90;
            if (direction % 2 == 0)
            {
                xPos = lane;
            }
            else
            {
                zPos = lane;
            }
            int carnumber = Random.Range(0,cars.Count-1);
            Quaternion target = Quaternion.Euler(0,rotation,0);
            GameObject newCar = Instantiate(cars[carnumber],new Vector3(xPos,0,zPos),target);
            Destroy(newCar,3);  
            yield return new WaitForSeconds(waitingSeconds);
        }
    }
}
