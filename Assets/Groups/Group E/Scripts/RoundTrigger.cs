using UnityEngine;

public class RoundTrigger : MonoBehaviour
{
    public GameManager_E gameManager;
    void OnTriggerEnter(Collider collision)
    {
        GameObject other = collision.gameObject;
        //gameManager.countRound(other);
    }
}
