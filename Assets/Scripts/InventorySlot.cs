using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot 
{
    public Item item;
    public int count;

    public InventorySlot(Item newItem)
    {
        item = newItem;
        count = 1;
    }
}
