using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWithOptionsNodeRenderer : NodeRenderer
{
    ChatWithOptionsNode _node;

    public ChatWithOptionsNodeRenderer(ChatWithOptionsNode node)
    {
        _node = node;
    }

    public override void Render(DialogueRenderer renderer)
    {
        renderer.DialogueLine.Line.text = _node.Text;
        for (int i = 0; i < _node.Options.Count; i++)
        {
            string outputPortName = nameof(_node.Options) + " " + i.ToString();
            renderer.OptionsContainer.AddOption(_node.Options[i], outputPortName);
        }
    }
}
