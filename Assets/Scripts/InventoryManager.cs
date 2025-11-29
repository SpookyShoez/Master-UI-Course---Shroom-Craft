using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<InventorySlot> inventory = new List<InventorySlot>();
    public InventorySlot equipmentHelmet = null;
    public InventorySlot equipmentWeapon = null;
    public InventorySlot equipmentChest = null;

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

    public void AssignEquipment(InventorySlot inventorySlot, ItemCategory itemCategory)
    {
        if (inventory.Contains(inventorySlot))
        return;

        inventory.Remove(inventorySlot);
        switch (itemCategory)
        {
            case ItemCategory.Weapon:
            equipmentWeapon = inventorySlot; break;
            case ItemCategory.Helmet:
            equipmentHelmet = inventorySlot; break; 
            case ItemCategory.Chest:
            equipmentChest = inventorySlot; break;
        }
    }

    public void MoveEquipmentToInventory(ItemCategory itemCategory)
    {
        switch (itemCategory)
        {
            case ItemCategory.Weapon:
            if (equipmentWeapon != null)
                {
                    inventory.Add(equipmentWeapon);
                    equipmentWeapon = null;
                }
                break;
            case ItemCategory.Helmet:
            if (equipmentHelmet != null)
                {
                    inventory.Add(equipmentHelmet);
                    equipmentHelmet = null;
                }
                break;
            case ItemCategory.Chest:
            if (equipmentChest != null)
                {
                    inventory.Add(equipmentChest);
                    equipmentChest = null;
                }
                break;

            
        }
    }
}
