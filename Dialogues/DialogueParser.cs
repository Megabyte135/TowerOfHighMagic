using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

public class DialogueParser
{
    BaseDialogueNode _currentNode;
    DialogueNodeGraph _dialogueGraph;

    public DialogueParser(DialogueNodeGraph graph)
    {
        _dialogueGraph = graph;
    }

    public BaseDialogueNode GetCurrentNode()
    {
        return _currentNode;
    }

    public BaseDialogueNode GetNextNode()
    {
        if (_currentNode == null)
        {
            _currentNode = _dialogueGraph.nodes.Find(x => x.Inputs.All(u => !u.IsConnected)) as BaseDialogueNode;
            return _currentNode;
        }
        else
        {
            _currentNode = _currentNode.Output as BaseDialogueNode;
        }
    }
}
