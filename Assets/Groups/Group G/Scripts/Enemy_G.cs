using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_G : Enum_Destroy
{
    public GameObject Explosion;
    public int HitPoints;
    public HealthBar HealthBar;
    public DestroyType CanBeDestroyedBy;

    public GameObject[] DropPowerUps;
    [Range(0.0f, 1.0f)]
    public float DropChance;

    private GameController_G GameController;
    private HealthSystem HealthSystem;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            GameController = gameControllerObject.GetComponent<GameController_G>();
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
            Collider otherCollider = other;
            
            if(otherCollider.tag == "Bullet")
            {
                if (otherCollider.GetComponent<CollisionExplosion>() != null)
                {
                    Instantiate(otherCollider.GetComponent<CollisionExplosion>().Explosion, otherCollider.transform.position, otherCollider.transform.rotation);
                    //if color is not the same we return, so no dmg to the enemy
                    if(CanBeDestroyedBy != DestroyType.All)
                    {
                        if(otherCollider.GetComponent<CollisionExplosion>().Type != CanBeDestroyedBy)
                        {
                            Destroy(otherCollider.gameObject);
                            return;
                        }
                    }
                }

                Destroy(otherCollider.gameObject);
            }
            HealthSystem.Damage(otherCollider.GetComponent<Attack>().Damage);
        }
        //on death
        if (Explosion != null && HealthSystem.GetHealth() == 0)
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
