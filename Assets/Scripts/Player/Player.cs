using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public KeyCode keyCodeRun = KeyCode.LeftShift; 

    private float _initialSpeed;
    private bool _isRunning;

    private Rigidbody2D _rig;
    private Vector2 _direction;


    public Vector2 direction { get {return _direction;} set {_direction = value;} }
    public bool isRunning { get {return _isRunning;} set {_isRunning = value;} }

    private void Start() {
        _rig = GetComponent<Rigidbody2D>();
        _initialSpeed = speed;
    }

    private void Update() {
        OnInput();
        OnRun();
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

    #endregion


}