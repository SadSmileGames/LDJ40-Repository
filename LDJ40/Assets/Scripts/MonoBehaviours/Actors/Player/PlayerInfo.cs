using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;
    public bool hasFood = false;
    public bool isHoldingKitten = false;

    private void Start()
    {
        instance = this;
        Debug.Log(instance.gameObject);
    }

    public void GiveFood()
    {
        if (!hasFood)
            hasFood = true;
    }
}
