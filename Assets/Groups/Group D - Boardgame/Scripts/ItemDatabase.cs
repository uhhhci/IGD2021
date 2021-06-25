using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    
    public List<ItemD> allItems;

    // mapping from item enum values to the respective item object
    private Dictionary<ItemD.Type, ItemD> itemDataBase;

    // Start is called before the first frame update
    void Start()
    {
         // fill/create the item lookup table
        itemDataBase = new Dictionary<ItemD.Type, ItemD>();

        foreach (ItemD item in allItems) {
            itemDataBase[item.type] = item;
        }        
    }

    public int getItemCount() {
        return allItems.Count;
    }

    public ItemD getItem(int index) {
        return itemDataBase[allItems[index].type];
    }

    public ItemD getItem(ItemD.Type type) {
        return itemDataBase[type];
    }
}
