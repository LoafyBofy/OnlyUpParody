using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private IInteraction _interactionObject;
    private CanInteractPopup _interactPopup;

    private void Start()
    {
        _interactPopup = FindAnyObjectByType<CanInteractPopup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _interactionObject))
        {
            _interactPopup?.Show(other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteraction _))
        {
            _interactPopup?.Hide();
            _interactionObject = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _interactionObject != null)
        {
            _interactionObject.Interact();
        }
    }
}
