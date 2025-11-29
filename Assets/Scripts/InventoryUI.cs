using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    [Header("Player Stats")]
    [SerializeField] TMP_Text attackStat;
    [SerializeField] TMP_Text defenseStat;
    [SerializeField] TMP_Text hpStat;

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
        // categoryFiltersTabs.SelectTab(0);

        // Reset
        foreach (var craftingSlot in craftingSlots)
        {
            craftingSlot.Initialize(null);
        }
        craftingResult.Initialize(null);
        equipmentWeapon.Initialize(InventoryManager.instance.equipmentWeapon);
        equipmentHelmet.Initialize(InventoryManager.instance.equipmentHelmet);
        equipmentChest.Initialize(InventoryManager.instance.equipmentChest);

        UpdateStats();
    }

    public void ChangeFilter(int id)
    {
        var items = InventoryManager.instance.inventory;
        if (id != 0)
        {
            ItemCategory category = (ItemCategory)(id - 1);
            items = InventoryManager.instance.inventory.FindAll(x => x.item.category == category);

        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            bool isEmpty = i >= items.Count;
            inventorySlots[i].Initialize(isEmpty ? null : items[i]);
        }
    }

    public void ChangedEquipmentSlot(InventorySlot inventorySlot, ItemCategory? itemCategory)
    {
        if (!itemCategory.HasValue)
        {
            return;
        }
        Debug.Log("Equipment Changed! " + itemCategory.Value.ToString());

        if (inventorySlot == null)
        {
            InventoryManager.instance.MoveEquipmentToInventory(itemCategory.Value);
        }else{
            InventoryManager.instance.AssignEquipment(inventorySlot, itemCategory.Value);
        }
        UpdateStats();
    }

    void UpdateStats()
    {
        int attack = 0;
        int defense = 0;
        int hp = 300;

        //update player stats
        AddStatFromItem(equipmentWeapon, ref attack, ref defense, ref hp);
        AddStatFromItem(equipmentHelmet, ref attack, ref defense, ref hp);
        AddStatFromItem(equipmentChest, ref attack, ref defense, ref hp);

        //update text
        attackStat.text = attack.ToString();
        defenseStat.text = defense.ToString();
        hpStat.text = hp.ToString();

        void AddStatFromItem(InventorySlotUI slot, ref int attack, ref int defense, ref int hp)
        {
            if (slot.slot == null) 
            return;

            attack += slot.slot.item.attack;
            attack += slot.slot.item.defense;
            attack += slot.slot.item.hp;
        }
    }
}
