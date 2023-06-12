using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPageLine : MonoBehaviour
{
    public Button KeyContainer;
    public TextMeshProUGUI View;

    [HideInInspector]public SettingsManager SettingsManager;
    [HideInInspector]public SettingsPage SettingsPage;
    
    [SerializeField][RequireInterface(typeof(IValueAccessor))]
    private UnityEngine.Object _valueContainer;
    public IValueAccessor ValueContainer => _valueContainer as IValueAccessor;
    private TextMeshProUGUI _key;
    private object _value;

    void Start()
    {
        _key = KeyContainer.GetComponentInChildren<TextMeshProUGUI>();
        _value = ValueContainer.GetValue();
    }

    public void UpdateValue()
    {
        _value = ValueContainer.GetValue();
        SubmitValueToSettings();
    }

    void SubmitValueToSettings()
    {
        SettingsManager.ChangeSetting(_key.text, _value);
    }
}
