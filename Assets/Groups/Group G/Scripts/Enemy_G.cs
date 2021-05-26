using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_G : MonoBehaviour
{
    public GameObject Explosion;
    public int HitPoints;
    public HealthBar HealthBar;

    public GameObject[] DropPowerUps;
    [Range(0.0f, 1.0f)]
    public float DropChance;

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

        EventSystemListeners.main.AddListener(gameObject);

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
                if (other.GetComponent<CollisionExplosion>() != null)
                {
                    Instantiate(other.GetComponent<CollisionExplosion>().Explosion, other.transform.position, other.transform.rotation);
                }

                Destroy(other.gameObject);
            }
        }
        //on death
        if(Explosion != null && HealthSystem.GetHealth() == 0)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            if (Random.Range(0f, 1f) <= DropChance)
            {
                DropPowerUp();
            }
            EventSystemListeners.main.RemoveListener(gameObject);
            Destroy(gameObject);
        }
    }

    private void DropPowerUp()
    {
        GameObject powerUp = DropPowerUps[Random.Range(0, DropPowerUps.Length)];
        GameObject go = Instantiate(powerUp, transform.position, transform.rotation);
        EventSystemListeners.main.AddListener(go);
    }
}
