using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    public Transform itemHolder;
    public bool isHoldingFood;

    private void Awake()
    {
        instance = this;
    }
}
