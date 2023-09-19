using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;
    public ANIMControl animControl;

    [Header("Stats")]
    public float totalHealth;
    public float currentHealth;
    public float radius;
    public Image healthBar;
    public LayerMask layer;
    public bool isDead;

    public Transform canvas;

    private Player _player;
    private bool _detectPlayer;


    void Start()
    {
        currentHealth = totalHealth;

        _player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        FollowTarget();
    }

    private void FixedUpdate() {
        DetectPlayer();
    }

    public void FollowTarget()
    {
        if (!isDead && _detectPlayer)
        {
            agent.isStopped = false;
            agent.SetDestination(_player.transform.position);

            float posX = _player.transform.position.x - transform.position.x;
            if (posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }

            PlayAnimation();
        }
    }

    public void PlayAnimation()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) <= agent.stoppingDistance)
        {
            //stop following player
            animControl.PlayAmin(2);
        }
        else
        {
            //follow player
            animControl.PlayAmin(1);
        }
    }

    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layer);

        if (hit != null)
        {
            //see player
            _detectPlayer = true;
        }
        else
        {
            //don't see player
            _detectPlayer = false;
            animControl.PlayAmin(0);

            agent.isStopped = true;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}