using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBurger : MonoBehaviour
{
    public GameObject burger;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(burgerSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator burgerSpawn()
    {
        while(true)
        {
            {
                int spawnRange = Random.Range(2,3);
                yield return new WaitForSeconds(spawnRange);
                Vector3 position = gameObject.transform.position + new Vector3(0,0.2f,0);
                Quaternion target = Quaternion.Euler(0,0,0);
                GameObject newBurger = Instantiate(burger,position,target);
            }

        }
        
    }
}
