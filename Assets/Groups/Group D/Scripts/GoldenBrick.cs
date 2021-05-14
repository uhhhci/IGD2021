using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBrick : MonoBehaviour
{

    public float rotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
    }
}
