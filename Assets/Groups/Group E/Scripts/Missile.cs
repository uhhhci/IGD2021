using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{

    private Rigidbody rb;
    public float missileSpeed = 150.0f;
    public GameObject explosionPrefab;


    public void Init()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerStats ps = collision.gameObject.GetComponent<PlayerStats>();
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            CarController playerController = collision.gameObject.GetComponent<CarController>();

            if(ps.hasShield)
            {
                ps.SlowRemoveShield();
                ps.StopShield();
            } else
            {
                playerRb.AddExplosionForce(1200f, gameObject.transform.position, 3.0f);
                playerController.StopCar();
            }

            AnimateExplosion(gameObject.transform);
            Destroy();
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

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
