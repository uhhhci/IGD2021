using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    public float batPower, homerunHeight;
    //public GameObject position;
    // Start is called before the first frame update
    void Start()
    {
        batPower = 100f;
        homerunHeight = 15f;
        //position = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject collidedPlayer = collision.gameObject;
            MinifigControllerWTH controller = collidedPlayer.GetComponent<MinifigControllerWTH>();
            if (!(controller == this.gameObject.GetComponentInParent<MinifigControllerWTH>()))
            {

                Vector3 pushDir = collidedPlayer.transform.position - transform.position;
                pushDir *= batPower;
                pushDir.y = homerunHeight;
                controller.AddForce(pushDir);
                Debug.Log("Schläger hat Spieler getroffen. Spieler fliegt richtung " + pushDir.ToString());
            }
        }
    }
}
