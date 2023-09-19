using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;

    public bool isPaused;

    public KeyCode keyCodeRun = KeyCode.LeftShift;
    public KeyCode keyCodeRoll = KeyCode.Mouse1;
    public KeyCode keyCodeTools = KeyCode.Mouse0;

    private float _initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;

    private Rigidbody2D _rig;
    private Vector2 _direction;

    private PlayerITEMS _playerITEMS;

    [HideInInspector] public int _handlingObj;

    public Vector2 direction { get {return _direction;} set {_direction = value;} }
    public bool isRunning { get {return _isRunning;} set {_isRunning = value;} }
    public bool isRolling { get {return _isRolling;} set {_isRolling = value;} }
    public bool isCutting { get {return _isCutting;} set {_isCutting = value;} }
    public bool isDigging { get {return _isDigging;} set {_isDigging = value;} }
    public bool isWatering { get {return _isWatering;} set {_isWatering = value;} }


    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _playerITEMS = GetComponent<PlayerITEMS>();
        _initialSpeed = speed;
    }

    void Update()
    {
        if (!isPaused)
        {
            HandlingObj();

            OnInput();
            OnRun();
            OnRolling();
            OnCutting();
            OnDig();
            OnWatering();
        }

    }

    private void FixedUpdate() {
        if (!isPaused)
        {
            OnMove();
        }
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
        if(_handlingObj == 0)
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
        else
        {
            _isCutting = false;
        }
    }

    void OnDig()
    {
        if(_handlingObj == 1)
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
        else
        {
            _isDigging = false;
        }

    }
    void OnWatering()
    {
        if(_handlingObj == 2)
        {
            if (Input.GetKeyDown(keyCodeTools) && _playerITEMS.currentWater > 0)
            {
                _isWatering = true;
                speed = 0f;
            }   
            if (Input.GetKeyUp(keyCodeTools) || _playerITEMS.currentWater < 0)
            {
                _isWatering = false;
                speed = _initialSpeed;
            }

            //water value drops when watering is true
            if (_isWatering)
            {
                _playerITEMS.currentWater-= 0.01f;
            }
        }
        else
        {
            _isWatering = false;   
        }

    }

    #endregion

    void HandlingObj()
    {
       if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _handlingObj = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _handlingObj = 2;
        }  
    }
}