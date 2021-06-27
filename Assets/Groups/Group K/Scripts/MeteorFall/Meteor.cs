using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _fallSpeed = 1.0f;
    [SerializeField] private Transform _decal;
    [SerializeField] private GameObject _Shockwave;

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

        SetDecalPosition();

        // for now
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDecalPosition()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.up, 20.0f);
        Vector3 highGround = new Vector3(0, 0, 0);
        float lastHitDistance = 1000;
        bool foundGround = false;
        foreach (RaycastHit hit in hits)
        {
            if(hit.collider.CompareTag("K_Ground"))
            {
                if(hit.distance < lastHitDistance)
                {
                    highGround = hit.point;
                    lastHitDistance = hit.distance;
                    foundGround = true;
                }
            }
        }
        if(foundGround)
        {
            _decal.position = highGround + new Vector3(0, 0.01f, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<RBCharacterController>().Explode(transform.position);
            Destroy(gameObject);
        }
        else if(collision.collider.CompareTag("K_Ground"))
        {
            Instantiate(_Shockwave, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
