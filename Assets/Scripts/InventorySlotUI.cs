using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Events;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Components")]
    [SerializeField] Image icon;
    [SerializeField] TMP_Text stackCountText;
    [SerializeField] Image frame;

    [Header("Settings")]
    [SerializeField] bool validateItemCategory;
    [SerializeField] public ItemCategory acceptedItemCategory;
    [SerializeField] Sprite spriteOneItem;
    [SerializeField] Sprite spriteMultipleItems;
    [SerializeField] public UnityEvent<InventorySlot, ItemCategory?> onItemChanged;

    public ItemCategory? AcceptedItemCategory {
    get {
        return validateItemCategory ? acceptedItemCategory : null;
        }
    }

    // Temp
    public InventorySlot slot;

    public void Initialize(InventorySlot newSlot) {
        slot = newSlot;
        icon.gameObject.SetActive(newSlot != null);
        if (newSlot == null)
        {
            stackCountText.gameObject.SetActive(false);
            frame.sprite = spriteOneItem;
            return;
        }
        icon.sprite = newSlot.item.sprite;
        stackCountText.text = newSlot.count.ToString();
        stackCountText.gameObject.SetActive(newSlot.count > 1);
        frame.sprite = newSlot.count > 1 ? spriteMultipleItems : spriteOneItem;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (slot != null) {
        ToolTipInstance.instance.Show(slot);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipInstance.instance.Hide();
    }
}

