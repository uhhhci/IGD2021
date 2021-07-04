using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{

    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;
    private Transform toFollow = null;

    public float missileSpeed = 150.0f;
    public GameObject explosionPrefab;


    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        
        {
            if(toFollow != null)
            {
                navMeshAgent.SetDestination(toFollow.position);
            }
            //Vector3 direction = toFollow.position - transform.position;
            //rb.velocity = direction.normalized * missileSpeed;
            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerStats ps = collision.gameObject.GetComponent<PlayerStats>();
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            CarController playerController = collision.gameObject.GetComponent<CarController>();
            if(collision.gameObject.TryGetComponent(out NavMeshAgent agent))
            {
                agent.enabled = false;
            }

            if(ps.hasShield)
            {
                ps.SlowRemoveShield();
                ps.StopShield();
            } else
            {
                if(agent == null)
                {
                    playerRb.AddExplosionForce(1200f, gameObject.transform.position, 3.0f);
                    playerController.StopCar();
                }

            }

            AnimateExplosion(gameObject.transform);
            Destroy();

            if(agent != null)
            {
                agent.enabled = true;
            }
        } 
    }

    private void AnimateExplosion(Transform explosionTransform)
    {
        GameObject explosionObject = Instantiate(explosionPrefab, explosionTransform.position, explosionTransform.rotation) as GameObject;
        explosionObject.SetActive(true);
        Destroy(explosionObject, 5.0f);
    }

    public void Shoot()
    {
        rb.velocity = transform.forward.normalized * missileSpeed;
    }

    public void Follow(Transform toFollow)
    {
        this.toFollow = toFollow;
        navMeshAgent.updatePosition = true;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
