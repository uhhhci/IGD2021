﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBrickManager : MonoBehaviour
{
    public Transform brick;

    public float hoverDistance = 1f;

    private Tile location;


    // Start is called before the first frame update
    void Start()
    {
        relocate();
    }

    public void relocate() {
        if (location) {
            location.setHasGoldenBrick(false);
        }

        // make sure that the start tile is not tagged/included
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        
        GameObject selected = tiles[Random.Range(0, tiles.Length)];
        location = selected.GetComponent(typeof(Tile)) as Tile;

        Vector3 newPos = selected.transform.position;
        newPos.y += hoverDistance;
        brick.position = newPos;

        location.setHasGoldenBrick(true);
    }
}
