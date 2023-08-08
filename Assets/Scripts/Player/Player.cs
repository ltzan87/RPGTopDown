using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public KeyCode keyCodeRun = KeyCode.LeftShift;
    public KeyCode keyCodeRoll = KeyCode.Mouse1;

    private float _initialSpeed;
    private bool _isRunning;
    private bool _isRolling;

    private Rigidbody2D _rig;
    private Vector2 _direction;

    public Vector2 direction { get {return _direction;} set {_direction = value;} }
    public bool isRunning { get {return _isRunning;} set {_isRunning = value;} }
    public bool isRolling { get {return _isRolling;} set {_isRolling = value;} }


    private void Start() {
        _rig = GetComponent<Rigidbody2D>();
        _initialSpeed = speed;
    }

    private void Update() {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        _rig.MovePosition(_rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(keyCodeRun))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(keyCodeRun))
        {
            speed = _initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetKeyDown(keyCodeRoll))
        {
            _isRolling = true;
        }
        if (Input.GetKeyUp(keyCodeRoll))
        {
            _isRolling = false;
        }
    }

    #endregion


}