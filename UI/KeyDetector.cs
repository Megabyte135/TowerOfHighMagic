using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    [HideInInspector]public KeyCode PressedKey = KeyCode.None;
    
    void Update()
    {
        if (Input.anyKeyDown)
        {
            PressedKey = GetPressedKey();
        }
        else
        {
            PressedKey = KeyCode.None;
        }
    }

    KeyCode GetPressedKey()
    {
        foreach(KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key))
            {
                return key;
            }
        }
        return KeyCode.None;
    }

    public IEnumerator DetectKeyCoroutine()
    {
        while (PressedKey == KeyCode.None)
        {
            yield return null;
        }
    }
}
