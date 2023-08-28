using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public KeyCode keyCodeRun = KeyCode.LeftShift;
    public KeyCode keyCodeRoll = KeyCode.Mouse1;
    public KeyCode keyCodeTools = KeyCode.Mouse0;

    private float _initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;

    private Rigidbody2D _rig;
    private Vector2 _direction;

    private int _handlingObj;

    public Vector2 direction { get {return _direction;} set {_direction = value;} }
    public bool isRunning { get {return _isRunning;} set {_isRunning = value;} }
    public bool isRolling { get {return _isRolling;} set {_isRolling = value;} }
    public bool isCutting { get {return _isCutting;} set {_isCutting = value;} }
    public bool isDigging { get {return _isDigging;} set {_isDigging = value;} }


    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _initialSpeed = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _handlingObj = 2;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDig();
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

    void OnCutting()
    {
        if(_handlingObj == 1)
        {
            if (Input.GetKeyDown(keyCodeTools))
            {
                _isCutting = true;
                speed = 0f;
            }
            if (Input.GetKeyUp(keyCodeTools))
            {
                _isCutting = false;
                speed = _initialSpeed;
            }
        }
    }

    void OnDig()
    {
        if(_handlingObj == 2)
        {
            if (Input.GetKeyDown(keyCodeTools))
            {
                _isDigging = true;
                speed = 0f;
            }   
            if (Input.GetKeyUp(keyCodeTools))
            {
                _isDigging = false;
                speed = _initialSpeed;
            }    
        }

    }

    #endregion
}