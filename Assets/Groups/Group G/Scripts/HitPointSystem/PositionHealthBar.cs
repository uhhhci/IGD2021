using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHealthBar : MonoBehaviour
{
    public GameObject ResetReference;
    public float healthBarOffset;
    public float healthBarOffsetY = 1.0f;
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(ResetReference.transform.position.x, ResetReference.transform.position.y + healthBarOffsetY, ResetReference.transform.position.z + healthBarOffset);
    }
}
