﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(GameObject prefab)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        GameManager.totalKittens++;
    }
}
