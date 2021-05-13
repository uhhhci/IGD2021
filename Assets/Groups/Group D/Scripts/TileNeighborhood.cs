using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNeighborhood : MonoBehaviour
{
    public TileNeighborhood left;
    public TileNeighborhood right;
    public TileNeighborhood up;
    public TileNeighborhood down;

    public Vector3 getPosition() {
        return this.transform.position;
    }
}
