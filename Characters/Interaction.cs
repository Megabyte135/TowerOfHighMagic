using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float InteractionDistance = 10.0f;
    public GameObject InteractionUI;
    private Interactable _interactableObject;

    void Update()
    {
        if (IsInteractionPossible())
        {
            InteractionUI.SetActive(true);
        }
        else
        {
            _interactableObject = null;
            InteractionUI.SetActive(false);
        }
    }

    public void Interact()
    {
        if (_interactableObject != null)
        {
            _interactableObject.Interact();
        }
    }

    bool IsInteractionPossible()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            Debug.Log("кек");

            _interactableObject = hit.collider.gameObject.GetComponent<Interactable>();
            if (_interactableObject != null)
            {
                return true;
            }
        }
        return false;
    }
}
