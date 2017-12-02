using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenInteractions : MonoBehaviour, IInteractable
{
    private KittenNeeds needs;
    private KittenController controller;

    private void Awake()
    {
        needs = GetComponent<KittenNeeds>();
        controller = GetComponent<KittenController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bathtub")
        {
            if (needs.currentNeeds == KittenNeeds.Needs.Cleaning)
            {
                needs.AddComfort(50f);
            }
            else
            {
                needs.AddComfort(-25f);
            }
        }
    }

    public void Interact()
    {
        if(needs.currentNeeds == KittenNeeds.Needs.Hungry)
        {
            if(PlayerInfo.instance.isHoldingFood)
            {
                needs.AddComfort(50f);
            }
        }

        if(needs.currentNeeds == KittenNeeds.Needs.Play)
        {
            needs.AddComfort(50f);
        }

        if(needs.currentNeeds == KittenNeeds.Needs.None)
        {
            controller.ToggleCarry();
        }
    }
}
