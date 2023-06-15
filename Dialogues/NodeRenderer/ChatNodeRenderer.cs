using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNodeRenderer : NodeRenderer
{
    readonly ChatNode _node;

    public ChatNodeRenderer(ChatNode chatNode)
    {
        _node = chatNode;
    }

    public override void Render(DialogueRenderer renderer)
    {
        renderer.DialogueLine.Line.text = _node.Text;
        renderer.WaitForClickToContinue();
    }
}
