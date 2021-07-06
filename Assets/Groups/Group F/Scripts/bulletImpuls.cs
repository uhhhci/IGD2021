using UnityEngine;

public class bulletImpuls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.collider.CompareTag("Player")) return;

        var rb = col.gameObject.GetComponent<Rigidbody>();
        var thisRb = this.GetComponent<Rigidbody>();
        rb.AddForce(thisRb.velocity, ForceMode.VelocityChange);
        Destroy(this);
    }
}
