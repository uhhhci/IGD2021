using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private GameObject grabbedPlayer;
    private bool tryGrabbing;
    private bool grabbing;


    // Start is called before the first frame update
    void Start()
    {
        tryGrabbing = false;
        grabbing = false;
    }

    void FixedUpdate()
    {
        if(grabbing)
        {
            Grab();
        }
    }

    void Grab()
    {
        RaycastHit hit;
        GameObject grabbedPlayer;

        if (Physics.Raycast(transform.position + new Vector3(0,0.25f,0), transform.forward, out hit, 1f)) // TODO greater area for the ray(s) to meet other players
        {
            if (hit.transform.gameObject.tag == "Player")
            { 
                grabbedPlayer = hit.collider.gameObject;
                // TODO: grab Player
                //grabbedPlayer.transform.parent = transform;
                //grabbedPlayer.transform.position = transform.position - transform.forward; //might need changing as it's untested.
                Debug.Log("Hit Player");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                grabbing = true;
            }
            else
            {
                grabbing = false;
            }
        }
        // else if (pickedUpObject != null)
        // { //if player is not holding E but was picking up an object last frame
        // pickedUpObject.transform.parent = null; //drop the object
        // pickedUpObject = null;  //and nullify the object pointer

        // }
    }

    public void StartGrabbing()
    {
        tryGrabbing = true;
        //Debug.Log("Start Grabbing");
        Grab();
    }

    public void StopGrabbing()
    {
        tryGrabbing = false;
        grabbing = false;
        if (grabbedPlayer != null)
        {
            grabbedPlayer.transform.parent = null;
            grabbedPlayer = null;
        }
        //Debug.Log("Stop Grabbing");
    }
}
