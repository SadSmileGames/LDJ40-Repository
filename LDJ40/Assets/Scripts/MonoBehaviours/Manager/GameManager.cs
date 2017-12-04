using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int totalKittens = 1;
    public static int kittensLeft = 3;

    public Vector2 timeBetweenKittenSpawns;
    private float timeBetweenKittenSpawnsCounter;

    public Text totalKittensText;

    public GameObject optionalPanel;
    public GameObject forcedPanel;

    public GameObject[] kittensLeftImages;

    private void Start()
    {
        timeBetweenKittenSpawnsCounter = timeBetweenKittenSpawns.y; 
    }

    private void Update()
    {
        CountUntilKittenSpawn();
        CheckForKittensLeft();
        totalKittensText.text = totalKittens.ToString();
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

    private void CheckForKittensLeft()
    {
        if (kittensLeft == 0)
            Debug.Log("GAME OVER");

        kittensLeftImages[kittensLeft].SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        optionalPanel.SetActive(false);
        forcedPanel.SetActive(false);
    }

   
}
