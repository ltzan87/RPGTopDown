using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player _player;
    private Animator _animator;


    private void Start() {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        if (_player.direction.sqrMagnitude > 0)
        {
            _animator.SetInteger("transition", 1);
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
    }
}