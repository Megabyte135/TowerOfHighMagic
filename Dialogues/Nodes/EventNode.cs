using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XNode;

public class EventNode : BaseDialogueNode
{
    public UnityEvent Events;

    public void Invoke()
    {
        Events.Invoke();
    }

    public override BaseDialogueNode NextNode()
    {
        throw new System.NotImplementedException();
    }
}
