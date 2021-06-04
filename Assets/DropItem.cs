using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropItem : MonoBehaviour
{
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        if (SpawnCar.bombCount<1){
                StartCoroutine(bombSpawn());
                SpawnCar.bombCount+=1;
        }

    }

    IEnumerator bombSpawn()
    {
        while(true)
        {
            {
                int spawnRange = Random.Range(2,3);
                yield return new WaitForSeconds(spawnRange);
                Vector3 position = gameObject.transform.position;
                Quaternion target = Quaternion.Euler(0,0,0);
                GameObject newBomb = Instantiate(bomb,position,target);
                yield return new WaitForSeconds(Random.Range(1,4)*4);
            }

        }
        
    }
}
