using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    public Sprite cropHole;
    public Sprite seed;

    [Header("Settings")]
    public KeyCode keyCodeHarvest = KeyCode.E;
    public int digAmount; //number of times need to dig to create a cropHole
    public int waterAmount; //total of water to grow

    [SerializeField] private bool _detecting;

    private int _initialDigAmount;
    private float _currentWater;
    private bool _dugHole;

    PlayerITEMS playerITEMS;


    void Start()
    {
        playerITEMS = FindAnyObjectByType<PlayerITEMS>();
        _initialDigAmount = digAmount;
    }

    void Update()
    {
        OnDugHole();
    }

    public void OnHit()
    {
        digAmount--;

        if (digAmount <= _initialDigAmount / 2)
        {
            //dig hole
            spriteRenderer.sprite = cropHole;
            _dugHole = true;
        }
    }
    
    public void OnDugHole()
    {
        if (_dugHole)
        {
            if (_detecting)
            {
                _currentWater += 0.01f;
            }

            //filled the amount of water needed
            if (_currentWater >= waterAmount)
            {
                //plant seed
                spriteRenderer.sprite = seed;

                if (Input.GetKeyDown(keyCodeHarvest))
                {
                    spriteRenderer.sprite = cropHole;   
                    playerITEMS.items++; 
                    _currentWater = 0f;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }

        if (collision.CompareTag("Water"))
        {
            _detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Water"))
        {
            _detecting = false;
        }
    }
}