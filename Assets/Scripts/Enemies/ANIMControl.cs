using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIMControl : MonoBehaviour
{
    private Animator _animator;


    private void Start() {
        _animator = GetComponent<Animator>();
    }

    public void PlayAmin(int value)
    {
        _animator.SetInteger("transition", value);
    }
}