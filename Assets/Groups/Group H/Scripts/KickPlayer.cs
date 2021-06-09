using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPlayer : MonoBehaviour
{
    public float kickForce = 0.5f;
    public float kickDistance = 1f;
    public float knockbackSpeed = 0.01f;
    public float knockbackDuration = 0.1f;

    public void Kick()
    {
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, kickDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Player")
        {
            Vector3 direction = hit.transform.gameObject.transform.position - transform.position;
            direction.Normalize();
            hit.collider.GetComponent<KickPlayer>().GetKicked(direction * kickForce);
        }
    }

    public void GetKicked(Vector3 direction)
    {
        StartCoroutine(Knockback(direction));
    }

    IEnumerator Knockback(Vector3 direction)
    {
        CharacterController controller = GetComponent<CharacterController>();
        float startTime = Time.time;
        while(Time.time < (startTime + knockbackDuration))
        {
            controller.SimpleMove(direction*knockbackSpeed);
            yield return null;
        }
    }
}
