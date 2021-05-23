using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_G : MonoBehaviour
{
    public GameObject Explosion;
    public int HitPoints;
    public HealthBar HealthBar;

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
        if(HealthBar != null)
        {
            HealthBar.Setup(HealthSystem);
        }
        
    }

    public HealthSystem GetHealthSystem()
    {
        return this.HealthSystem;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Obstacle" || other.tag == "Enemy")
        {
            return;
        }

        if (other.GetComponent<Attack>() != null)
        {
            HealthSystem.Damage(other.GetComponent<Attack>().Damage);
            if(other.tag == "Bullet")
            {
                Destroy(other.gameObject);
            }
        }

        if(Explosion != null && HealthSystem.GetHealth() == 0)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
