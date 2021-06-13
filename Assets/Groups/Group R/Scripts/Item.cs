using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string type;
    public bool isPickedUp = false;

    private GameObject player;

    public Vector3 posOffset;
    public Vector3 rotOffset;

    public int strength = 20;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isPickedUp){
            transform.Rotate(new Vector3(0f,2.0f,0f) , Space.World);
            if(transform.position.y < -10)
                Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObj = collision.gameObject;
        if(!isPickedUp && gameObj.tag=="Player" && !gameObj.GetComponent<OurMinifigController>().hasItem){
            isPickedUp = true;
            gameObj.GetComponent<OurMinifigController>().hasItem = true;
            gameObj.GetComponent<OurMinifigController>().itemType = type;
            player = gameObj;
            var tree = new List<int>(){0,1,0,1,0,0,0,0,0,0,2,0,0,1,0,0,2};
            Transform child = gameObj.transform;
            foreach (var subtree in tree)
            {
                child = child.GetChild(subtree);
            }
            transform.SetParent(child);
            transform.localPosition = posOffset;
            transform.localRotation = Quaternion.Euler(rotOffset);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }else if(isPickedUp && gameObj.tag=="Player" && gameObj != player && player.GetComponent<OurMinifigController>().isHitting){
            OurMinifigController hit_player = gameObject.GetComponent<OurMinifigController>();
            if(!hit_player){
                Debug.Log(gameObj.name);
            }
            hit_player.damage += strength;
            Vector3 hit_direction = hit_player.transform.position - transform.position;
            hit_direction.x = 0f; // do not change x position
            hit_direction.y += 1f; // make the hit player fly slightly upwards
            if (hit_direction.z > 0)
                hit_direction.z = 1f;
            else
                hit_direction.z = -1f;
            hit_direction.Normalize();
            float dmg_scale = (hit_player.damage + 10) * 0.01f;
            hit_player._knockback += hit_direction * dmg_scale;
        }
    }
}
