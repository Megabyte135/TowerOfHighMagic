using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWindow : MonoBehaviour
{
    public GameObject WindowToActivate;
    public GameObject WindowToDeactivate;

    public void Switch()
    {
        WindowToActivate.SetActive(true);
        if (WindowToDeactivate != null)
        {
            WindowToDeactivate.SetActive(false);
        }
    }
}
