using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueRenderer : MonoBehaviour
{
    public GameObject DialogueContainer;
    public DialogueLine DialogueLine;
    public OptionsContainer OptionsContainer;
    public Button InteractiveZone;
    public PlayerInput PlayerInput;
    public List<GameObject> ElementsToDisable;
    DialogueParser DialogueParser;

    void Start()
    {
        OptionsContainer.AddButtonAction((outputPort) => RenderNextNode(outputPort));
        InteractiveZone.onClick.AddListener(Continue);
        InteractiveZone.gameObject.SetActive(false);
    }

    public void StartRendering(DialogueNodeGraph nodeGraph)
    {
        EnterDialogueMode();
        DialogueParser = new DialogueParser(nodeGraph);
        RenderNextNode();
    }

    void RenderNextNode(string outputPort = "")
    {
        BaseDialogueNode? nextNode;
        if (outputPort == "")
        {
            nextNode = DialogueParser.GetNextNode();
        }
        else
        {
            nextNode = DialogueParser.GetNextNode(outputPort);
        }
        if (nextNode == null)
        {
            StopRendering();
        }
        else
        {
            OptionsContainer.ClearOptions();
            nextNode.RenderAccordingTo(this);
        }
    }

    void StopRendering()
    {
        ExitDialogueMode();
    }

    public void WaitForClickToContinue()
    {
        InteractiveZone.gameObject.SetActive(true);
    }

    void Continue()
    {
        InteractiveZone.gameObject.SetActive(false);
        RenderNextNode();
    }

    void EnterDialogueMode()
    {
        PlayerInput.enabled = false;
        DialogueContainer.SetActive(true);
        foreach (var item in ElementsToDisable)
        {
            item.gameObject.SetActive(false);
        }
    }

    void ExitDialogueMode()
    {
        PlayerInput.enabled = true;
        DialogueContainer.SetActive(false);
        foreach (var item in ElementsToDisable)
        {
            item.gameObject.SetActive(true);
        }
    }
}