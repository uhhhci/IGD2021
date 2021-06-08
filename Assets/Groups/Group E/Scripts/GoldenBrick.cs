using System.Collections;
using UnityEngine;

public class GoldenBrick : MonoBehaviour
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
        ps.hasGoldenBrick = true;

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(5);

        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
