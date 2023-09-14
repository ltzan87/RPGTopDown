using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack Settings")]
    public Transform attackPoint;
    public float radius;
    public LayerMask enemyLayer;
   
    private Player _player;
    private Animator _animator;

    private Fishing _cast;

    private bool _isHiting;
    private float _timeCount;
    private float _recoveryTime = 1f;


    void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();

        _cast = FindObjectOfType<Fishing>();
    }

    void Update()
    {
        OnMove();
        OnRun();

        Delay();
    }
    
    #region Movement

    void OnMove()
    {
        if (_player.direction.sqrMagnitude > 0)
        {
            if (_player.isRolling)
            {
                _animator.SetTrigger("isRoll");
            }
            else
            {
                _animator.SetInteger("transition", 1);
            }
        }
        else
        {
            _animator.SetInteger("transition", 0);
        }

        if (_player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2 (0, 0);
        }
        if (_player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2 (0, 180);
        }

        if (_player.isCutting)
        {
            _animator.SetInteger("transition", 3);
        }
        if (_player.isDigging)
        {
            _animator.SetInteger("transition", 4);
        }
        if (_player.isWatering)
        {
            _animator.SetInteger("transition", 5);
        }
    }

    void OnRun()
    {
        if (_player.isRunning)
        {
            _animator.SetInteger("transition", 2);
        }
    }

    #endregion

    #region Attack

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);

        if (hit != null)
        {
            //hit enemy
            Debug.Log("HIT ENEMy");
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

    #endregion

    public void OnCastingStart()
    {
        _animator.SetTrigger("isFishing");
        _player.isPaused = true;
    }
    public void OnCastingEnd()
    {
        _cast.OnCasting();
        _player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        _animator.SetBool("hammering", true);
    }
    public void OnHammeringEnded()
    {
        _animator.SetBool("hammering", false);
    }

    public void OnHit()
    {
        if (!_isHiting)
        {
            _animator.SetTrigger("hit");
            _isHiting = true;
        }
    }

    public void Delay()
    {
        if (_isHiting)
        {
            _timeCount += Time.deltaTime;

            if (_timeCount >= _recoveryTime)
            {
                _isHiting = false;
                _timeCount = 0f;
            }
        }
    }
}