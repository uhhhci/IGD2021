
using UnityEngine;

public class playercollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag == "Respawn")
        {
            print("respawn");
        }
        
            
            
        
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ItemCollect")
        {
            print("colcol");
            Destroy(col.gameObject);
        }
    }

}
