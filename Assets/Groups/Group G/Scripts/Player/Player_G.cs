using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_G : MonoBehaviour
{
    public int HitPoints = 100;
    public HealthBar HealthBar;
    public GameObject Explosion;
    
    private GameController GameController;
    private HealthSystem HealthSystem;
    private bool IsInvulnerable;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            GameController = gameControllerObject.GetComponent<GameController>();
        }
        if (GameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        HealthSystem = new HealthSystem(HitPoints);
        HealthBar.Setup(HealthSystem);

    }
    public HealthSystem GetHealthSystem()
    {
        return this.HealthSystem;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") return;

        if (other.tag == "Obstacle" || other.tag == "Enemy")
        {
            // Lose health only if we're not invulnerable
            if (!IsInvulnerable && other.GetComponent<Attack>() != null)
            {
                HealthSystem.Damage(other.GetComponent<Attack>().Damage);
                SendPlayerHurtMessages();
                
            }
            
        }

        // Remove Player when we have no Health
        if (HealthSystem.GetHealth() == 0)
        {
            if(Explosion != null)
            {
                Instantiate(Explosion, transform.position, transform.rotation);
            }
            GameController.RemovePlayer(gameObject);
            Destroy(gameObject);
        }

        // Some collision explosion and destroying enemies with no health on collision
        if (other.GetComponent<Enemy_G>() != null)
        {
            if(other.GetComponent<CollisionExplosion>() != null)
            {
                Instantiate(other.GetComponent<CollisionExplosion>().Explosion, other.transform.position, other.transform.rotation);
            }
            if (other.GetComponent<Enemy_G>().GetHealthSystem().GetHealth() == 0)
            {
                Destroy(other.gameObject);
            }
        }
    }

    public void SetInvulnerability(bool isInvulnerabilityOn)
    {
        IsInvulnerable = isInvulnerabilityOn;
    }

    private void SendPlayerHurtMessages()
    {
        
        // Send message to any listeners
        foreach (GameObject go in EventSystemListeners.main.listeners)
        {
            ExecuteEvents.Execute<IPlayerEvents>(go, null, (x, y) => x.OnPlayerHurt(HealthSystem.GetHealth()));
        }
    }

}