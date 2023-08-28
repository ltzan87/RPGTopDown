using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite cropHole;
    public Sprite seed;

    [SerializeField]private int _digAmount; //number of times you have to dig to create a cropHole

    private int _initialDigAmount;


    void Start()
    {
        _initialDigAmount = _digAmount;
    }

    void Update()
    {
        
    }

    public void OnHit()
    {
        _digAmount--;

        if (_digAmount <= _initialDigAmount / 2)
        {
            //dig hole
            spriteRenderer.sprite = cropHole;
        }

       /* if (_digAmount <= 0)
        {
            //plant seed
            spriteRenderer.sprite = seed;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }
    }
}