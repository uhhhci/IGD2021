﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Credit_Turn : MonoBehaviour
{
    public float rotationSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate( 0, rotationSpeed * Time.deltaTime, 0);
    }
}
