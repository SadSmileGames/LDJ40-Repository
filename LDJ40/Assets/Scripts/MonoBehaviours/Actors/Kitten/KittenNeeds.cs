using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenNeeds : MonoBehaviour
{
    public enum Needs { None, Hungry, Cleaning, Play };
    public Needs currentNeeds;

    public Slider stressBar;
    public Text currentNeedsText;

    public Color stressedColor;
    public Color relaxedColor;

    public float maxComfortLevel = 100f;
    public float comfortDecrease = 2f;

    public float timeBetweenNeeds = 10f;

    private float timeBetweenNeedsCounter;

    private float currentComfortLevel = 100f;
    private float currentComfortDecrease = 2f;


    private void Start()
    {
        currentComfortLevel = maxComfortLevel;
        currentComfortDecrease = comfortDecrease;
        stressBar.value = maxComfortLevel;
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
        stressBar.value = currentComfortLevel;

        if (currentComfortLevel <= 0)
        {
            GameManager.kittensLeft--;
            Destroy(this.gameObject);
        }

        if (currentComfortLevel <= 50 && currentNeeds == Needs.None)
        {
            currentNeeds = (Needs)UnityEngine.Random.Range(1, 4);
            currentNeedsText.text = currentNeeds.ToString();
            currentComfortDecrease = comfortDecrease * 1.5f;
            stressBar.fillRect.GetComponent<Image>().color = stressedColor;
        }

        if(currentComfortLevel > 50 && currentNeeds != Needs.None)
        {
            currentNeeds = Needs.None;
            currentNeedsText.text = "";
            currentComfortDecrease = comfortDecrease;
            stressBar.fillRect.GetComponent<Image>().color = relaxedColor;
        }   
    }

    private void DestroyThis()
    {
        
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
