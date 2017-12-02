using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldInteraction : MonoBehaviour
{

    [Tooltip("The LayerMask of the interactable objects. All objects that don't have this Mask will be ignored!")]
    public LayerMask interactableLayer;
    [Tooltip("The radius of the interaction range.")]
    public float interactionRange;

    private void Update()
    {
        // Check if we are clicking and make sure we are not pointing over a UI Element
        if (Input.GetButtonDown("Interact"))
        {
            GetInteraction();
        }
    }

    /// <summary>
    /// Does a OverlapSphere cast to check if any interactabkle objects are nearby.
    /// If so, interact with the closest one
    /// </summary>
    private void GetInteraction()
    {
        // Creates an array of colliders and fills it with an OverlapSphere cast
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer);

        // Check if anything has been hit
        if (colliders.Length > 0)
        {
            // Only interact with the closest interactable
            Collider2D closestCollider = colliders[0];
            float closestDistanceFromPlayer = Vector2.Distance(this.transform.position, colliders[0].transform.position);

            // Loop through all the colliders that we hit
            foreach (Collider2D coll in colliders)
            {
                // This is used to store the distance of the current coll to the player
                float currentDistanceFromPlayer = Vector2.Distance(this.transform.position, coll.transform.position);

                // Check if the current coll is closer then the closest distance yet
                if (currentDistanceFromPlayer <= closestDistanceFromPlayer)
                {
                    //Set the closest collider to coll & update the closest distance
                    closestDistanceFromPlayer = currentDistanceFromPlayer;
                    closestCollider = coll;
                }
            }

            // Now finally check if the closest collider is an interactible
            if (closestCollider.GetComponent<IInteractable>() != null)
            {
                closestCollider.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
