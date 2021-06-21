using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType {
        GAIN_COINS,
        LOSE_COINS,
        MASTER_HAND,
        RANDOM_EVENT,
        START,
    }

    public TileType type;
    public Tile left;
    public Tile right;
    public Tile up;
    public Tile down;

    private Tile toBrick;

    private static HashSet<Tile> visited = new HashSet<Tile>();
    private static Queue<Tile> frontierA = new Queue<Tile>();
    private static Queue<Tile> frontierB = new Queue<Tile>();

    bool trapPresent;
    int trapOwner;
    public GameObject trapObject;

    private bool goldenBrickPresent;
    public bool itemShopPresent;

    public Vector3 getPosition() {
        return this.transform.position;
    }

    public bool hasItemShop() {
        return itemShopPresent;
    }

    public bool hasGoldenBrick() {
        return goldenBrickPresent;
    }

    public void setHasGoldenBrick(bool newValue) {
        goldenBrickPresent = newValue;

        if (newValue) {
            visited.Clear();
            frontierA.Clear();
            frontierB.Clear();
            setToGoldenBrick(null);

            while (frontierA.Count > 0) {
                frontierA.Dequeue().setToGoldenBrick(frontierB.Dequeue());
            }
        }
    }

    /// returns the neighbor tile which is the next on the shortest path the golden brick
    /// returns null when this tile contains the brick
    public Tile nextOnPathToBrick() {
        return toBrick;
    }

    /// sets the neighbor in which direction the golden brick is located
    /// uses cicle detection
    /// pass null to indicate that this tile contains the golden brick
    private void setToGoldenBrick(Tile tile) {
        toBrick = tile;
        updateNeighbor(left);
        updateNeighbor(right);
        updateNeighbor(up);
        updateNeighbor(down);
    }

    private void updateNeighbor(Tile neighbor) {
        if (neighbor != null && !visited.Contains(neighbor)) {
            visited.Add(neighbor);
            frontierA.Enqueue(neighbor);
            frontierB.Enqueue(this);
        }
    }

    public bool hasTrap(){
        return trapPresent;
    }

    public void setTrap(bool newValue, GameObject trap=null, int player=-1)
    {
        trapPresent = newValue;
        trapOwner = player;
        trapObject = trap;
    }
    
    public void destroyTrap()
    {
        Destroy(trapObject);
        trapObject = null;
    }

    public int getTrapOwner()
    {
        return trapOwner;
    }

    public GameObject getTrap()
    {
        return trapObject;
    }
}
