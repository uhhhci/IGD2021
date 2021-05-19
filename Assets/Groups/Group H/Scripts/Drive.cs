using UnityEngine;

public class Drive : MonoBehaviour
{
    public Rigidbody car;
    public Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        car.AddForce(direction * Time.deltaTime);
    }
}
