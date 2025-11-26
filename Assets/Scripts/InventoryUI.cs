using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject inventoryGo;
    [SerializeField] GameObject inventorySlotsGrid;

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
    }

    public void ChangeFilter(int id)
    {
        ItemCategory category = (ItemCategory)id;

        var items = InventoryManager.instance.inventory.FindAll(x => x.item.category == category);
        for (int i = 0; i < inventorySlots.Length; i++) 
        {
            bool isEmpty = i >= items.Count;
            inventorySlots[i].Initialize(isEmpty ? null : items[i]);
        }
    }
}
