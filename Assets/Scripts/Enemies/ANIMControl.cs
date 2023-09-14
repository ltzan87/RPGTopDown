using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMControl : MonoBehaviour
{
    public Transform attackPoint;
    public float radius;
    public LayerMask playerLayer;
    
    private Animator _animator;


    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void PlayAmin(int value)
    {
        _animator.SetInteger("transition", value);
    }

    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if (hit != null)
        {
            Debug.Log("bateu no player");
        }
        else
        {
            
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}