using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipInstance : MonoBehaviour
{
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

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
