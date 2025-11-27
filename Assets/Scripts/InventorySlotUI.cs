using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Components")]
    [SerializeField] Image icon;
    [SerializeField] TMP_Text stackCountText;
    [SerializeField] Image frame;

    [Header("Settings")]
    [SerializeField] Sprite spriteOneItem;
    [SerializeField] Sprite spriteMultipleItems;

    // Temp
    InventorySlot slot;

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

