using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    // Start is called before the first frame update

    //public Vector2 spawnPosition;
    public float lifetime = 1.0f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
