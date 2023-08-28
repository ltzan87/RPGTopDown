using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerITEMS : MonoBehaviour
{
    public int totalWood;

    public float currentWater;
    private float _waterLimit = 50f;

    public void WaterLimit(float water)
    {
        if (currentWater <= _waterLimit)
        {
            currentWater += water;
        }

    }
}