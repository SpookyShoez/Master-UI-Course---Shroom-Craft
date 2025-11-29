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
                // debug log
                Debug.Log(acceptedItemCategory.HasValue ? "Accepted category: " + acceptedItemCategory.Value.ToString() : "Accepted any category");
                slotUnderCursor.Initialize(originalSlot.slot);
                slotUnderCursor.onItemChanged?.Invoke(originalSlot.slot, slotUnderCursor.AcceptedItemCategory);
                originalSlot.onItemChanged?.Invoke(null, originalSlot.AcceptedItemCategory);
                originalSlot.Initialize(null);
            }
        }

        transform.SetParent(originalSlot.transform);
        transform.localPosition = Vector2.zero;

        canvasGroup.blocksRaycasts = true;
        return;
    }
}
