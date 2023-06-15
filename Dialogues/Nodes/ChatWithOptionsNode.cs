using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWithOptionsNode : ChatNode
{
    [Output(dynamicPortList = true)] public List<string> Options;

    public override void RenderAccordingTo(DialogueRenderer dialogueRenderer)
    {
        ChatWithOptionsNodeRenderer nodeRenderer = new ChatWithOptionsNodeRenderer(this);
        nodeRenderer.Render(dialogueRenderer);
    }
}
