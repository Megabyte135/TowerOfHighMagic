using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static string interactableMask = "Interactable";
    public IInteractable InteractionAction => _interactionAction as IInteractable;
    [SerializeField][RequireInterface(typeof(IInteractable))] private UnityEngine.Object _interactionAction;
    
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer(interactableMask);
    }

    public void Interact()
    {
        InteractionAction.Interact();
    }
}
