using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Image icon;
    [SerializeField] Image background;

    //Temp
    public TabsManager tabsManager;

    public void Initialize(TabsManager tabsManager)
    {
        this.tabsManager = tabsManager;
    }

    public void Select()
    {
        icon.color = Color.black;
        background.color = Color.white;
    }

    public void Deselect()
    {
        icon.color = Color.white;
        background.color = new Color32(255, 255, 255, 18);
    }

    public void OnClick()
    {
        tabsManager.SelectTab(this);
    }
}
