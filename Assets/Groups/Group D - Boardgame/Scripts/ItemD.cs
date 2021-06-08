using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemD : MonoBehaviour
{
    public GameObject inventoryPrefab; // the prefab of the item's model/game object which will be displayed in the inventory
    public Type type; // the type of this item
    public int creditPrice; // price of this item in the shop
    public string description; // a short description of this item and what is does

    public enum Type {
        CREDIT_THIEF,
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getPrice() {
        return creditPrice;
    }

    public string getDescription() {
        return description;
    }
}
