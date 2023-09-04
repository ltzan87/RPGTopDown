using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerITEMS : MonoBehaviour
{
    [Header("Amounts")]
    public int totalWood;
    public int items;
    public int fishes;
    public float currentWater;

    private float _waterLimit = 50f;
    private float _woodLimit = 10f;
    private float _carrotsLimit = 15f;
    private float _fishesLimit = 5f;

    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float carrotsLimit { get => _carrotsLimit; set => _carrotsLimit = value; }
    public float fishesLimit { get => _fishesLimit; set => _fishesLimit = value; }

    public void WaterLimit(float water)
    {
        if (currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }
}