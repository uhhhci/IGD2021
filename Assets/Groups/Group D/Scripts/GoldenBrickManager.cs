using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBrickManager : MonoBehaviour
{
    public Transform brick;

    public float hoverDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        relocate();
    }

    public void relocate() {
        // make sure that the start tile is not tagged/included
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        Vector3 newPos = tiles[Random.Range(0, tiles.Length)].transform.position;
        newPos.y += hoverDistance;
        brick.position = newPos;
    }
}
