using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KeyDetector))]
[RequireComponent(typeof(SettingsPageLine))]
public class KeyInput : MonoBehaviour
{
    public ToggleWindow KeyInputWindow;
    [HideInInspector] public KeyCode EnteredKey = KeyCode.None;
    private SettingsPageLine _settingsPageLine;
    private KeyDetector _keyDetector;
    private bool _isWaitingForInput = false;

    private void Start()
    {
        _keyDetector = GetComponent<KeyDetector>();
        _settingsPageLine = GetComponent<SettingsPageLine>();
    }

    public void WaitForInput()
    {
        if (!_isWaitingForInput)
        {
            _isWaitingForInput = true;
            KeyInputWindow.Toggle();
            StartCoroutine(WaitForInputCoroutine());
        }
    }

    IEnumerator WaitForInputCoroutine()
    {
        yield return StartCoroutine(_keyDetector.DetectKeyCoroutine());
        EnteredKey = _keyDetector.PressedKey;
        KeyInputWindow.Toggle();
        _isWaitingForInput = false;
        _settingsPageLine.ValueContainer.SetValue(EnteredKey);
        _settingsPageLine.UpdateValue();
    }
}
