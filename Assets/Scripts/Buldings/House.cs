using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{   
    public KeyCode keyCodeBuild = KeyCode.E;

    [Header("Amounts")]
    public Color startColor;
    public Color endColor;
    public float timeAmount;
    public int woodAmount;

    [Header("Components")]
    public GameObject houseColl;
    public SpriteRenderer houseSprite;
    public Transform point;

    private bool _playerDetected;
    private bool _isBeginnig;
    private float _timeCount;
    
    private Player _player;
    private PlayerAnim _playerAnim;
    private PlayerITEMS _playerITEMS;


    void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _playerAnim = _player.GetComponent<PlayerAnim>();
        _playerITEMS = _player.GetComponent<PlayerITEMS>();
    }

    void Update()
    {
        StartBuilding();
    }

    public void StartBuilding()
    {
        if (_playerDetected && Input.GetKeyDown(keyCodeBuild) && _playerITEMS.totalWood >= woodAmount)
        {
            //is started
            _isBeginnig = true;
            _playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            _player.transform.position = point.position;
            _player.transform.rotation = point.rotation;
            _player.isPaused = true;
            _playerITEMS.totalWood -= woodAmount;
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
                houseColl.SetActive(true);
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