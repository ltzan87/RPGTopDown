using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMControl : MonoBehaviour
{
    public Transform attackPoint;
    public float radius;
    public LayerMask playerLayer;
    
    private Animator _animator;
    private PlayerAnim _player;
    private Skeleton _skeleton;


    private void Start() {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<PlayerAnim>();
        _skeleton = GetComponentInParent<Skeleton>();
    }

    public void PlayAmin(int value)
    {
        _animator.SetInteger("transition", value);
    }

    public void Attack()
    {
        if (!_skeleton.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

            if (hit != null)
            {
                //hit player
                _player.OnHit();
            }
        }
    }

    public void OnHit()
    {
        if (_skeleton.currentHealth <= 0)
        {
            _animator.SetTrigger("death");
            _skeleton.isDead = true;

            Destroy(_skeleton.gameObject, 1f);
        }
        else
        {
            _animator.SetTrigger("hit");
            _skeleton.currentHealth--;

            _skeleton.healthBar.fillAmount = _skeleton.currentHealth / _skeleton.totalHealth;
        }

    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}