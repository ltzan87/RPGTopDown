using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float treeHealth;

    public GameObject woodPFB;
    public int totalWood;
    public ParticleSystem leafs;

    [SerializeField] private Animator _animator;


    public void OnHit()
    {
        treeHealth--;

        _animator.SetTrigger("isHit");
        leafs.Play();
        if (treeHealth <= 0)
        {
            //create and instantiate drops
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPFB, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);    
            }
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