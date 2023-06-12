using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleValueAccessor : MonoBehaviour, IValueAccessor
{
    public Toggle Toggle;

    public object GetValue()
    {
        return Toggle.isOn;
    }

    public void SetValue(object value)
    {
        Toggle.SetIsOnWithoutNotify(Convert.ToBoolean(value));
    }
}