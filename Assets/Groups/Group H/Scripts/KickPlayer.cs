using UnityEngine;

public class KickPlayer : MonoBehaviour
{
    public float kickDistance = 1f;
    public float kickForce;

    public void Kick()
    {
        Collider collider = GetComponent<Collider>();
        RaycastHit hit;

        bool hitDetected = Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hit, transform.rotation, kickDistance);
        if (hitDetected && hit.transform.gameObject.tag == "Player")
        {
            hit.collider.GetComponent<KickPlayer>().GetKicked(-hit.normal.normalized * kickForce);
        }
    }

    public void GetKicked(Vector3 direction)
    {
        CharacterController charController = GetComponent<CharacterController>();
        charController.enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        Debug.Log(rb);
        Debug.Log(direction);
        rb.AddForce(direction);
        charController.enabled = true;
    }
}
