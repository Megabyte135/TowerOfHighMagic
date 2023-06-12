using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    [HideInInspector]public List<TabButton> TabButtons;
    public Color TabIdle;
    public Color TabActive;
    public Color TabHover;
    public TabButton SelectedTab;
    public List<GameObject> ObjectsToSwap;
    public void Subscribe(TabButton button)
    {
        if (TabButtons == null)
        {
            TabButtons = new List<TabButton>();
        }
        TabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(SelectedTab == null || button != SelectedTab)
        {
            button.Background = TabHover;
        }
    }
    
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        SelectedTab = button;
        ResetTabs();
        button.Background = TabActive;
        int index = button.transform.GetSiblingIndex();
        ActivateObject(index);
    }

    void ActivateObject(int index)
    {
        for (int i = 0; i < TabButtons.Count; i++)
        {
            if (i == index)
            {
                ObjectsToSwap[i].SetActive(true);
            }
            else
            {
                ObjectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in TabButtons)
        {
            if(button != null && button == SelectedTab)
            {
                continue;
            }
            button.Background = TabIdle;
        }
    }
}
