using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public float speed;
    public float timeMove;

    private float _timeCount;


    void Update()
    {
        _timeCount += Time.deltaTime;

        if (_timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerITEMS>().totalWood++;
            Destroy(gameObject);
        }
    }
}