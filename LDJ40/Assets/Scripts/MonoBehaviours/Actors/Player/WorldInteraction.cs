using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    public LayerMask interactionMask;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            CheckForInteractable();
        }
    }

    private void CheckForInteractable()
    {
        Vector3 mousePosition = Input.mousePosition; //Sets the Position of the Mouse/Touch to the mouse position on Screen
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //Transforms the mouse Position  into a Vector 3

        Collider2D interactable = Physics2D.OverlapPoint(mousePosition, interactionMask);
        
        if (interactable != null)
        {
            Debug.Log(interactable.name);
            interactable.GetComponent<IInteractable>().Interact();
        }
    }
}
