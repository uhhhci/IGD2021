using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        destroyParticle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroyParticle()
    {
        ParticleSystem parts = gameObject.GetComponent<ParticleSystem>();
        float totalDuration = parts.duration + parts.startLifetime;
        Destroy(gameObject, totalDuration);
    }
}
