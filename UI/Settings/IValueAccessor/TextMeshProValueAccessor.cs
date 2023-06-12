using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextMeshProValueAccessor : MonoBehaviour, IValueAccessor
{
    public TextMeshProUGUI TextMeshPro;

    public object GetValue()
    {
        return TextMeshPro.text;
    }

    public void SetValue(object value)
    {
        TextMeshPro.text = value.ToString();
    }
}