using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ToolTipInstance : MonoBehaviour
{

    public static ToolTipInstance instance;

    [Header("Components")]
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text amount;

    [Header("Components - stats")]
    [SerializeField] GameObject attackGo;
    [SerializeField] TMP_Text attackValue;
    [SerializeField] GameObject defenceGo;
    [SerializeField] TMP_Text defenceValue;
    [SerializeField] GameObject hpGo;
    [SerializeField] TMP_Text hpValue;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    private void Awake()
    {
        instance = this;
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        transform.position = Input.mousePosition;
        CalculatePivotPoint();
    }

    void CalculatePivotPoint() 
    {
        Vector2 tooltipSize = rectTransform.sizeDelta;

        Vector2 tooltipPosition = rectTransform.anchoredPosition;
        
        float rightEdgeDelta = -tooltipPosition.x;
        bool flipX = rightEdgeDelta < tooltipSize.x;

        float bottomEdgeDelta = tooltipPosition.y;
        bool flipY = bottomEdgeDelta < tooltipSize.y;

        rectTransform.pivot = new Vector2(flipX ? 1 : 0, flipY ? 0 : 1);
    }

    public void Show(InventorySlot inventorySlot)
    {
        canvasGroup.alpha = 1;
        
        title.text = inventorySlot.item.name;
        amount.text = "Amount: " + inventorySlot.count.ToString();

        // Stats
        attackGo.SetActive(inventorySlot.item.attack > 0);
        attackValue.text = inventorySlot.item.attack.ToString();
        defenceGo.SetActive(inventorySlot.item.defense > 0);
        defenceValue.text = inventorySlot.item.defense.ToString();
        hpGo.SetActive(inventorySlot.item.hp > 0);
        hpValue.text = inventorySlot.item.hp.ToString();
    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
    }
}
