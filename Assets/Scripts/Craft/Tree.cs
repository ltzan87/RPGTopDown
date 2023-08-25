using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float treeHealth;

    [SerializeField] private Animator _animator;


    public void OnHit()
    {
        treeHealth--;

        _animator.SetTrigger("isHit");

        if (treeHealth <= 0)
        {
            //create and instantiate drops
            _animator.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}