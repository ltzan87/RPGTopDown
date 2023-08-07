using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rig;
    private Vector2 _direction;


    private void Start() {
        _rig = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate() {
        _rig.MovePosition(_rig.position + _direction * speed * Time.fixedDeltaTime);
    }
}