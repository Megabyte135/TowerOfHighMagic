using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XNode;

public class ChatNode : BaseDialogueNode
{
    [TextArea] public string Text;

    public override void RenderAccordingTo(DialogueRenderer renderer)
    {
        ChatNodeRenderer chatNodeRenderer = new ChatNodeRenderer(this);
        chatNodeRenderer.Render(renderer);
    }
}
