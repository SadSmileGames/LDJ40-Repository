using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitten : MonoBehaviour, IInteractable
{
    public enum Needs {None, Hungry, Cleaning, Play};

    public float maxComfortLevel = 100f;
    public float comfortDecrease = 2f;

    private float currentComfortLevel = 100f;
    private float currentComfortDecrease = 2f;

    public Needs currentNeeds;

    private bool isCarried = false;

    private void Start()
    {
        currentComfortLevel = maxComfortLevel;
        currentComfortDecrease = comfortDecrease;
    }

    private void Update()
    {
        DecreaseComfortLevel();
        CheckForComfortLevel();
        CheckForCarried();
    }

    private void CheckForCarried()
    {
        if(isCarried)
            transform.position = PlayerInfo.instance.itemHolder.position;
    }

    private void CheckForComfortLevel()
    {
        if(currentComfortLevel <= 50 && currentNeeds == Needs.None)
        {
            currentNeeds = (Needs)UnityEngine.Random.Range(1, 4);
            currentComfortDecrease = comfortDecrease * 0.5f;
        }

        if(currentComfortLevel > 50 && currentNeeds != Needs.None)
        {
            currentNeeds = Needs.None;
            currentComfortDecrease = comfortDecrease;
        }
    }

    private void DecreaseComfortLevel()
    {
        currentComfortLevel -= currentComfortDecrease * Time.deltaTime;

        if (currentComfortLevel < 0)
            currentComfortLevel = 0f;
    }

    public void AddComfort(float amount)
    {
        currentComfortLevel += amount;

        if (currentComfortLevel > 100f)
            currentComfortLevel = 100f;

        if (currentComfortLevel < 0)
            currentComfortLevel = 0f;
    }

    public void Interact()
    {
        if(PlayerInfo.instance.isHoldingFood == false)
        {
            if (isCarried == true)
                isCarried = false;
            else
                isCarried = true;
        }
    }
}
