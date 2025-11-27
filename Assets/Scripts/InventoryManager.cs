using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<InventorySlot> inventory = new List<InventorySlot>();
    public InventorySlot equipmentHelmet;
    public InventorySlot equipmentWeapon;
    public InventorySlot equipmentChest;

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(Item newItem) {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].item == newItem && inventory[i].item.stackable)
            {
                inventory[i].count++;
                return;
            }
        }
        inventory.Add(new InventorySlot(newItem));
    }
}
