using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;

    private GameController GameController;

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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Obstacle" || other.tag == "Enemy")
        {
            return;
        }

        if(Explosion != null)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }
        
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            GameController.RemovePlayer(other.gameObject);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
