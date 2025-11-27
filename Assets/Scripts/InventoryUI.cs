using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject inventoryGo;
    [SerializeField] GameObject inventorySlotsGrid;
    [SerializeField] TabsManager categoryFiltersTabs;

    [Header("Other InventorySlotUIs")]
    [SerializeField] InventorySlotUI[] craftingSlots = null;
    [SerializeField] InventorySlotUI craftingResult = null;
    [SerializeField] InventorySlotUI equipmentWeapon = null;
    [SerializeField] InventorySlotUI equipmentHelmet = null;
    [SerializeField] InventorySlotUI equipmentChest = null;

    //Temp
    InventorySlotUI[] inventorySlots;

    void Awake()
    {
        inventorySlots = inventorySlotsGrid.GetComponentsInChildren<InventorySlotUI>();
    }


    void Start()
    {
        inventoryGo.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool inventoryVisible = inventoryGo.activeInHierarchy;
            inventoryGo.SetActive(!inventoryVisible);
            if (inventoryVisible == false)
            {
                InventoryOpened();
            }
        }
    }

        void InventoryOpened()
    {
       ChangeFilter(0);
       categoryFiltersTabs.SelectTab(0);
       
       // Reset
       foreach (var craftingSlot in craftingSlots)
       {
            craftingSlot.Initialize(null);
       }
       craftingResult.Initialize(null);
       equipmentWeapon.Initialize(InventoryManager.instance.equipmentWeapon);
       equipmentHelmet.Initialize(InventoryManager.instance.equipmentHelmet);
       equipmentChest.Initialize(InventoryManager.instance.equipmentChest);
    }

    public void ChangeFilter(int id) {
        var items = InventoryManager.instance.inventory;
        if (id != 0) {
        ItemCategory category = (ItemCategory)(id - 1);
        items = InventoryManager.instance.inventory.FindAll(x => x.item.category == category);

        }
        
        for (int i = 0; i < inventorySlots.Length; i++) 
        {
            bool isEmpty = i >= items.Count;
            inventorySlots[i].Initialize(isEmpty ? null : items[i]);
        }
    }
 }
