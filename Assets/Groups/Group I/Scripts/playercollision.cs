
using UnityEngine;

public class playercollision : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider col)
    {
        GameObject obj = col.gameObject;

        if (obj.tag == "ItemCollect")
        {
            PickUp(obj);
            // todo xyz
        }

        if (obj.tag == "SomethingElse")
        {
            PickUp(obj);
            // todo xyz
        }

    }

    private void PickUp(GameObject obj)
    {
        Debug.Log("Picked up: " + obj.tag);
        Destroy(obj);
    }

}
