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
            if(other.GetComponent<Attack>() != null)
            {
                HealthSystem.Damage(other.GetComponent<Attack>().Damage);
                SendPlayerHurtMessages();
                
            }
            
        }
        if (Explosion != null && HealthSystem.GetHealth() == 0)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            GameController.RemovePlayer(gameObject);
            Destroy(gameObject);
        }

        if (other.GetComponent<Enemy_G>() != null)
        {
            if (other.GetComponent<Enemy_G>().GetHealthSystem().GetHealth() == 0)
            {
                Destroy(other.gameObject);
            }
        }
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