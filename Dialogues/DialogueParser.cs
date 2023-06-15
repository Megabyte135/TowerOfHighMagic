using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using UnityEngine;
using XNode;

public class DialogueParser
{
    Node _currentNode;
    DialogueNodeGraph _dialogueGraph;

    public DialogueParser(DialogueNodeGraph graph)
    {
        _dialogueGraph = graph;
        _currentNode = _dialogueGraph.nodes.FirstOrDefault(u => u.GetType() == typeof(StartNode));
    }

    public BaseDialogueNode? GetNextNode(string outputPortName = "Output")
    {
        var connection = _currentNode.GetOutputPort(outputPortName).Connection;
        if (connection == null)
        {
            return null;
        }
        _currentNode = connection.node as BaseDialogueNode;
        return _currentNode as BaseDialogueNode;
    }
}
