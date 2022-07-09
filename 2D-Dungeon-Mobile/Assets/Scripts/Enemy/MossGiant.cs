using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim; 

    private void Start() 
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        //if idle animation
        //do nothing
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    void Movement()
    {
        //if current pos == point A
        //move to pointB
        //else if current pos == point B
        //move to pointA

        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
            
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
            
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
