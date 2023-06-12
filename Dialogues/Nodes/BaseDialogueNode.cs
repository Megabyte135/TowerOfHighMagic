using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class BaseDialogueNode : Node
{
    [Input] public Node Input;
    [Output] public Node Output;
    public NodeRenderer Renderer;

    public abstract BaseDialogueNode NextNode();

    public override 
}
