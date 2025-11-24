using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    List<Item> inventory = new List<Item>();

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(Item newItem) {
        inventory.Add(newItem);
    }
 
}
