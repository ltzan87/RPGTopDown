using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public NavMeshAgent agent;
    public ANIMControl animControl;

    private Player _player;


    void Start()
    {
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