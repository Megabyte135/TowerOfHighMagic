using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XNode;

public class DialogueNode : BaseDialogueNode
{
    [Input] public Node Input;
    [Output] public Node Output;
    [TextArea] public string Text;

    public override BaseDialogueNode NextNode()
    {
        throw new System.NotImplementedException();
    }
}
