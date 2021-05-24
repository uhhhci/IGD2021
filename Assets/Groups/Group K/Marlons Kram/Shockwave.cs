﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [SerializeField] private float _radius = 5.0f;
    [SerializeField] private float _speed = 0.2f;
    [SerializeField] private Transform _sphere;

    private List<string> _alreadyHit;
    private float _currRadius;

    // Start is called before the first frame update
    void Start()
    {
        _alreadyHit = new List<string>();
        _currRadius = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _currRadius += _speed * _radius * Time.deltaTime;

        _sphere.transform.localScale = new Vector3(_currRadius, _currRadius, _currRadius) * 2;

        if(_currRadius <= _radius)
        {
            List<string> currHits = new List<string>();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _currRadius);
            foreach (Collider hitCollider in hitColliders)
            {
                if(hitCollider.CompareTag("Player"))
                {
                    currHits.Add(hitCollider.name);

                    if(!_alreadyHit.Contains(hitCollider.name))
                    {
                        RBCharacterController controller = hitCollider.GetComponent<RBCharacterController>();
                        if(controller.GroundCheck())
                        {
                            controller.GetStunned();
                        }
                    }
                }
            }
            _alreadyHit = currHits;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _currRadius);
    }
}
