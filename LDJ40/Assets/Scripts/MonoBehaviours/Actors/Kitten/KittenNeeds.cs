using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenNeeds : MonoBehaviour
{
    public enum Needs { None, Hungry, Cleaning, Play };

    public float maxComfortLevel = 100f;
    public float comfortDecrease = 2f;

    public float timeBetweenNeeds = 10f;

    private float timeBetweenNeedsCounter;

    private float currentComfortLevel = 100f;
    private float currentComfortDecrease = 2f;

    public Needs currentNeeds;

    private void Start()
    {
        currentComfortLevel = maxComfortLevel;
        currentComfortDecrease = comfortDecrease;
    }

    private void Update()
    {
        if (timeBetweenNeedsCounter <= 0)
            DecreaseComfortLevel();
        else
            timeBetweenNeedsCounter -= Time.deltaTime;

        CheckComfortLevel();        
    }

    private void CheckComfortLevel()
    {
        if(currentComfortLevel <= 50 && currentNeeds == Needs.None)
        {
            currentNeeds = (Needs)UnityEngine.Random.Range(1, 4);
            currentComfortDecrease = comfortDecrease * 0.25f;
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

        if (currentComfortLevel > 50f)
            timeBetweenNeedsCounter = timeBetweenNeeds;
    }
}
