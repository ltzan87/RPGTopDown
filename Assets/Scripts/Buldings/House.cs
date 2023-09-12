using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{   
    public KeyCode keyCodeBuild = KeyCode.E;
    public SpriteRenderer houseSprite;
    public Transform point;
    public Color startColor;
    public Color endColor;
    public float timeAmount;


    private bool _playerDetected;
    private bool _isBeginnig;
    private float _timeCount;
    
    private Player _player;
    private PlayerAnim _playerAnim;


    void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _playerAnim = _player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        StartBuilding();
    }

    public void StartBuilding()
    {
        if (_playerDetected && Input.GetKeyDown(keyCodeBuild))
        {
            _isBeginnig = true;
            _playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            _player.transform.position = point.position;
            _player.isPaused = true;
        }

        if (_isBeginnig)
        {
            _timeCount += Time.deltaTime;
            if (_timeCount >= timeAmount)
            {
                //is finished
                _playerAnim.OnHammeringEnded();
                houseSprite.color = endColor;
                _player.isPaused = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            _playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            _playerDetected = false;
        }
    }
}