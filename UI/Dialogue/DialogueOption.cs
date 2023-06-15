using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DialogueOption : MonoBehaviour
{
    public Button Button;
    public TextMeshProUGUI TextContainer;
    public string OutputPortName;

    void Start()
    {
        Button = GetComponent<Button>();
    }
}
