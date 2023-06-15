using System;
using UnityEngine;
using UnityEngine.Events;

public class OptionsContainer : MonoBehaviour
{
    public DialogueOption OptionPrefab;
    public UnityAction<string> ButtonAction;

    public void AddButtonAction(UnityAction<string> action)
    {
        ButtonAction = action;
    }

    public void AddOption(string text, string outputPort)
    {
        var option = Instantiate(OptionPrefab.gameObject, transform).GetComponent<DialogueOption>();
        option.TextContainer.text = text;
        option.OutputPortName = outputPort;
        option.Button.onClick.AddListener(() => ButtonAction(outputPort));
    }

    public void ClearOptions()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            Destroy(child);
        }
    }
}
