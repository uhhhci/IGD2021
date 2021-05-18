using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _fallSpeed = 1.0f;
    [SerializeField] private Transform _decal;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.up, 20.0f);
        // filter player out
        _decal.position = hits[0].collider.transform.position + new Vector3(0, 0.01f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - transform.up * Time.deltaTime * _fallSpeed;


        RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.up, 20.0f);
        // filter player out
        
        _decal.position = hits[0].point + new Vector3(0, 0.01f, 0);

        // for now
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // for now eliminate players
            collision.collider.GetComponent<RBCharacterController>().Explode();
        }
    }
}
