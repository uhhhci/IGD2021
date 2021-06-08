using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // the delay in seconds
    private float invincibleTime = 2.4f;
    private float blinkingTime = 0.4f;

    // the audio file for the sound that the figure should make when getting hit
    public AudioClip explodeAudioClip;

    public CapsuleCollider collider;
    public GameObject minifigCharacter;
    private bool isHidden;
    private bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        isHidden = false;
        invincible = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Vehicle" && !invincible )
        {
            invincible = true;
            StartCoroutine(EnableInvincibility(invincibleTime));
        }
    }

    void takeDamage()
    {
        if(!invincible)
        {
        invincible = true;
        StartCoroutine(EnableInvincibility(invincibleTime));
        Debug.Log("Damage Taken");
        }
    }

    IEnumerator EnableInvincibility(float time)
    {
        // deactivate collisions
        //collider.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(explodeAudioClip);

        // make player blink
        for (float i = 0; i < time; i += blinkingTime)
        {
            ToggleVisibility();
            yield return new WaitForSeconds(blinkingTime);
        }
        // activate collisions
        //collider.enabled = true;
        invincible = false;
    }

    void ToggleVisibility()
    {
        if (isHidden)
        {
            minifigCharacter.transform.localScale = Vector3.one;
        }
        else
        {
            minifigCharacter.transform.localScale = Vector3.zero;
        }
        isHidden = !isHidden;
    }
}
