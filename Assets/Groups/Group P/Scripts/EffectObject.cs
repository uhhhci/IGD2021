using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    // Start is called before the first frame update

    //public Vector2 spawnPosition;
    public float lifetime = 0.5f;
    public float scaling = 1.01f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color = new Color(color.r, color.g, color.b, color.a * (1f-2f*Time.deltaTime));
        gameObject.GetComponent<SpriteRenderer>().color = color;
        transform.localScale =  (1f+Time.deltaTime) * transform.localScale;
    }
}
