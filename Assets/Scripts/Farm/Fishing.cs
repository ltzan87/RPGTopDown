using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public KeyCode keyCodeFishing = KeyCode.E;
    public GameObject fishPFB;

    private bool _playerDetected;
    
    [SerializeField] private int _percentage; //percentage chance of catching a fish

    private PlayerITEMS _player;
    private PlayerAnim _playerAnim;


    void Start()
    {
        _player = FindAnyObjectByType<PlayerITEMS>();
        _playerAnim = _player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        Casting();
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

    public void Casting()
    {
        if (_playerDetected && Input.GetKeyDown(keyCodeFishing))
        {
            _playerAnim.OnCastingStart();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue <= _percentage)
        {
            //caught a fish
            Instantiate(fishPFB, _player.transform.position + new Vector3(Random.Range(-2.5f,-1), 0f, 0f), Quaternion.identity);
            Debug.Log("pescou");
        }
        else
        {
            //didn't catch a fish
            Debug.Log("nao pescou");
        }
    }
}