using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueAccessor : MonoBehaviour, IValueAccessor
{
    public Slider Slider;

    public object GetValue()
    {
        return Slider.value;
    }

    public void SetValue(object value)
    {
        Slider.SetValueWithoutNotify(Convert.ToSingle(value));
    }
}