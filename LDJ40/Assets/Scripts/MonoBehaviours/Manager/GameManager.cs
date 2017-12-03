using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int totalKittens = 1;

    public Vector2 timeBetweenKittenSpawns;
    private float timeBetweenKittenSpawnsCounter;

    //I HATE MYSELF-
    public GameObject optionalPanel;
    public GameObject forcedPanel;

    private void Start()
    {
        timeBetweenKittenSpawnsCounter = timeBetweenKittenSpawns.x; 
    }

    private void Update()
    {
        CountUntilKittenSpawn();
    }

    private void CountUntilKittenSpawn()
    {
        if (timeBetweenKittenSpawnsCounter > 0)
            timeBetweenKittenSpawnsCounter -= Time.deltaTime;

        if(timeBetweenKittenSpawnsCounter < 0)
        {
            if (totalKittens < 3)
                optionalPanel.SetActive(true);
            else
                forcedPanel.SetActive(true);

            Time.timeScale = 0.000000001f;

            timeBetweenKittenSpawnsCounter = Random.Range(timeBetweenKittenSpawns.x, timeBetweenKittenSpawns.y);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        optionalPanel.SetActive(false);
        forcedPanel.SetActive(false);
    }
}
