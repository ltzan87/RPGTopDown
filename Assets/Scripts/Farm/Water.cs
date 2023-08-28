using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public KeyCode keyCodeWater = KeyCode.E;

    [SerializeField] private int waterValue;

    private bool _playerDetected;
    
    private PlayerITEMS _player;

    void Start()
    {
        _player = FindAnyObjectByType<PlayerITEMS>();
    }

    void Update()
    {
        CollectingWater();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            _playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            _playerDetected = false;
        }
    }

    public void CollectingWater()
    {
        if (_playerDetected && Input.GetKeyDown(keyCodeWater))
        {
            _player.WaterLimit(waterValue);
        }
    }
}