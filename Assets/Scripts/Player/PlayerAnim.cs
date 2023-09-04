using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player _player;
    private Animator _animator;

    private Fishing _cast;

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
}