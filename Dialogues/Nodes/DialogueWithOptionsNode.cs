using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWithOptionsNode : DialogueNode
{
    [Output(dynamicPortList = true)] public List<string> Options;
}
