using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Image icon;
    [SerializeField] TMP_Text stackCountText;
    [SerializeField] Image frame;

    [Header("Settings")]
    [SerializeField] Sprite spriteOneItem;
    [SerializeField] Sprite spriteMultipleItems;

    public void Initialize(InventorySlot newSlot) {
        icon.gameObject.SetActive(newSlot != null);
        if (newSlot == null)
        {
            return;
        }
        icon.sprite = newSlot.item.sprite;
        stackCountText.text = newSlot.count.ToString();
        stackCountText.gameObject.SetActive(newSlot.count > 1);
        frame.sprite = newSlot.count > 1 ? spriteMultipleItems : spriteOneItem;
    }
}

