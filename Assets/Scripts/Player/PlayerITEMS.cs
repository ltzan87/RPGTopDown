using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerITEMS : MonoBehaviour
{
    [Header("Amounts")]
    public int totalWood;
    public int items;
    public float currentWater;

    private float _waterLimit = 50f;
    private float _woodLimit = 10f;
    private float _carrotsLimit = 15f;

    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float carrotsLimit { get => _carrotsLimit; set => _carrotsLimit = value; }

    public void WaterLimit(float water)
    {
        if (currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }
}