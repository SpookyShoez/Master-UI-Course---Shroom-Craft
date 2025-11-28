using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Temp
    InventorySlotUI originalSlot;
    CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        originalSlot = GetComponentInParent<InventorySlotUI>();
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        GameObject goUnderCursor = eventData.pointerEnter.gameObject;
        InventorySlotUI slotUnderCursor = goUnderCursor.GetComponent<InventorySlotUI>();
        if (slotUnderCursor != null && slotUnderCursor != originalSlot && slotUnderCursor.slot == null)
        {
            ItemCategory? acceptedItemCategory = slotUnderCursor.AcceptedItemCategory;
            if (!acceptedItemCategory.HasValue ||
             (acceptedItemCategory.HasValue && acceptedItemCategory.Value == originalSlot.slot.item.category))
            {
                slotUnderCursor.Initialize(originalSlot.slot);
                originalSlot.Initialize(null);
                slotUnderCursor.onItemChanged?.Invoke(originalSlot.slot, slotUnderCursor.AcceptedItemCategory);
                originalSlot.onItemChanged?.Invoke(null, originalSlot.AcceptedItemCategory);
            }
        }

        transform.SetParent(originalSlot.transform);
        transform.localPosition = Vector2.zero;

        canvasGroup.blocksRaycasts = true;
        return;
    }
}
