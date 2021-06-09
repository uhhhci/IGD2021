using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerUp : MonoBehaviour
{
    public string Name;
    public bool ExpiresImmediately;
    public GameObject PickUpEffect;
    public AudioClip SoundEffect;

    protected Player_G Player;
    protected PlayerController PlayerController;
    private ParticleSystem ParticleSystem;
    private Collider Collider;

    protected virtual void Awake()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
        Collider = GetComponent<Collider>();

    }
    protected virtual void Start()
    {
        State = PowerUpState.InAttractMode;
    }

    protected enum PowerUpState
    {
        InAttractMode,
        IsCollected,
        IsExpiring
    }

    protected PowerUpState State;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PowerUpCollected(other.gameObject);
        }
    }

    protected virtual void PowerUpCollected(GameObject player)
    {
        if (State == PowerUpState.IsCollected || State == PowerUpState.IsExpiring)
        {
            return;
        }
        State = PowerUpState.IsCollected;


        PlayerController = player.GetComponent<PlayerController>();
        Player = player.GetComponent<Player_G>();

        gameObject.transform.parent = Player.gameObject.transform;
        gameObject.transform.position = Player.gameObject.transform.position;

        // Collection effects
        PowerUpEffects();

      
        // Payload      
        PowerUpPayload();
        
        // Send message to any listeners
        foreach (GameObject go in EventSystemListeners.main.listeners)
        {
            ExecuteEvents.Execute<IPowerUpEvents>(go, null, (x, y) => x.OnPowerUpCollected(this, Player));
        }


        
        Collider.enabled = false;
    }

    protected virtual void PowerUpEffects()
    {
        if (PickUpEffect != null)
        {
            Instantiate(PickUpEffect, transform.position, transform.rotation);
        }

        if (SoundEffect != null && Player.gameObject.GetComponent<AudioSource>() != null)
        {
            Player.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundEffect);
        }
    }

    protected virtual void PowerUpPayload()
    {
        if (ExpiresImmediately)
        {
            PowerUpHasExpired();
        }
    }

    protected virtual void PowerUpHasExpired()
    {
        if (State == PowerUpState.IsExpiring)
        {
            return;
        }
        State = PowerUpState.IsExpiring;

        
        // Send message to any listeners
        foreach (GameObject go in EventSystemListeners.main.listeners)
        {
            ExecuteEvents.Execute<IPowerUpEvents>(go, null, (x, y) => x.OnPowerUpExpired(this, Player));
        }
        
        DestroySelfAfterDelay();
    }

    protected virtual void DestroySelfAfterDelay()
    {
        ParticleSystem.Stop();
        Destroy(gameObject, 10f);
    }
    
}
