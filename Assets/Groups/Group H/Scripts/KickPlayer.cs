using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPlayer : MonoBehaviour
{
    Vector3 yOffset = new Vector3(0, 0.25f, 0);
    Vector3 viewingAngle = new Vector3(0.1f, 0, 0);
    public float kickDistance = 1f;
    public float kickForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kick()
    {
        RaycastHit hit;
        GameObject kickedPlayer;

        if (Physics.Raycast(transform.position + yOffset, transform.forward + viewingAngle, out hit, kickDistance) 
            || Physics.Raycast(transform.position + yOffset, transform.forward + viewingAngle, out hit, kickDistance))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                kickedPlayer = hit.collider.gameObject;
                Debug.Log("Hit Player");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                float distance = Vector3.Distance(kickedPlayer.transform.position, transform.position);
                Vector3 kickDirection = kickedPlayer.transform.position - transform.position;
                kickDirection = kickDirection / distance; // normalize direction
                print(kickDirection);
                Rigidbody rb = kickedPlayer.GetComponent<Rigidbody>();
                print(rb);
                rb.AddForce(kickForce * kickDirection);

            }
        }
    }
}
