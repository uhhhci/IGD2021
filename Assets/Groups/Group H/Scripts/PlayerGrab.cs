using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{

    public float grabDistance = 1f;

    private GameObject grabbedPlayer;
    private bool grabbing;


    // Start is called before the first frame update
    void Start()
    {
        grabbing = false;
    }

    void FixedUpdate()
    {
        if (grabbing)
        {
            Grab();
        }
    }

    public void Grab()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, grabDistance);
        if (!grabbing && hitDetected && hit.transform.gameObject.tag == "Player")
        {
            grabbedPlayer = hit.collider.gameObject;
            grabbedPlayer.GetComponent<PlayerGrab>().GetGrabbedBy(transform);

            grabbing = true;
        }
        else if (!grabbing)
        {
            StopGrabbing();
        }
    }

    public void StopGrabbing()
    {
        grabbing = false;
        if (grabbedPlayer != null)
        {
            grabbedPlayer.GetComponent<PlayerGrab>().StopGettingGrabbed();
            grabbedPlayer = null;
        }
    }

    public void GetGrabbedBy(Transform otherPlayer)
    {
        MinifigControllerH minifigController = GetComponent<MinifigControllerH>();
        minifigController.Follow(otherPlayer);
    }

    public void StopGettingGrabbed()
    {
        MinifigControllerH minifigController = GetComponent<MinifigControllerH>();
        minifigController.StopFollowing();
        //minifigController.SetInputEnabled(true);
    }
}
