using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // point where the player respawns
    private Vector3 respawnPoint;
    // a small offset to prevent the player from falling through the floor
    private Vector3 yOffset = new Vector3(0,1f,0);
    // the delay in seconds
    private float respawnDelay = 2f;
    // the audio file for the sound that the figure should make when getting destroyed
    public AudioClip explodeAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Treffer");
        if(other.gameObject.tag == "Vehicle")
        {
            StartCoroutine(PlayerRespawn());
        }
    }

    IEnumerator PlayerRespawn()
    {
        // let the player vanish
        Physics.IgnoreLayerCollision(gameObject.layer, 13, true);
        gameObject.transform.position = new Vector3(0, 100, 0);
        gameObject.transform.localScale = Vector3.zero;

        GetComponent<AudioSource>().PlayOneShot(explodeAudioClip);

        // TODO block player movement

        // wait a little bit
        yield return new WaitForSeconds(respawnDelay);

        // respawn the player at his starting point
        gameObject.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        gameObject.transform.position = respawnPoint + yOffset;
        Physics.IgnoreLayerCollision(gameObject.layer, 13, false);
    }

    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            // sometimes the figure falls through the floor and I dont know why or what to do to fix it
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        }
    }
}
