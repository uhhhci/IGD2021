using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float Lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

}
