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
    public Image healthBar;
    public bool isDead;

    public Transform canvas;

    private Player _player;


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

    public void FollowTarget()
    {
        if (!isDead)
        {   
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
}