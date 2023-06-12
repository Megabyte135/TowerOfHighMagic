using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaking : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Speak();
    }

    public void Speak()
    {
        Debug.Log("So it begins...");
    }
}
