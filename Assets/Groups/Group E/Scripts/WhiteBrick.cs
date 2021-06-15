using System.Collections;
using UnityEngine;

public class WhiteBrick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
            
        }
    }

    public IEnumerator Pickup(Collider player)
    {
        PlayerStats ps = player.GetComponent<PlayerStats>();
        ps.hasWhiteBrick = true;
        ps.imageWhiteBrick.enabled = true;

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(5);

        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
