using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabsManager : MonoBehaviour
{

    [SerializeField] UnityEvent<int> onTabSelected;

    Tab[] tabs;

    void Start()
    {
        tabs = GetComponentsInChildren<Tab>();
        foreach (var tab in tabs)
        {
            tab.Initialize(this);
        }
        Debug.Log("Found " + tabs.Length + " tabs!");
        SelectTab(tabs[0]);
    }

    public void SelectTab(Tab selectedTab)
    {
        foreach (var tab in tabs)
        {
            tab.Deselect();
        }
        selectedTab.Select();
        onTabSelected?.Invoke(selectedTab.transform.GetSiblingIndex());
    }
    public void SelectTab(int selectedTabIndex)
    {
        SelectTab(tabs[selectedTabIndex]);

    }
}
