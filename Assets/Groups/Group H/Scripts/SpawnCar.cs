using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public List<GameObject> cars;
    public int xPos;
    public int zPos;
    public float rotation;
    public int carcount;
    public int carnumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(carSpawn());
    }
    IEnumerator carSpawn()
    {
        while (carcount < 2)
        {
            xPos = Random.Range(-2,2)*2;
            zPos = Random.Range(-2,2)*2;
            rotation = Random.Range(0,3)*90;
            carnumber = Random.Range(0,7);
            Quaternion target = Quaternion.Euler(0,rotation,0);
            GameObject newCar = Instantiate(cars[carnumber],new Vector3(xPos,0,zPos),target);
            carcount =0;
            Destroy(newCar,3);  
            yield return new WaitForSeconds(2);
            Debug.Log("Super! Auto erstellt!"+" "+xPos+" "+zPos+" "+rotation);
            
        }
    }
    
}
