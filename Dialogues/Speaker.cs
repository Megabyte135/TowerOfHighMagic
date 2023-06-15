using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour, IInteractable
{
    public DialogueNodeGraph DialogueGraph;
    public DialogueRenderer DialogueRenderer;

    public void Interact()
    {
        DialogueRenderer.StartRendering(DialogueGraph);
    }
}
