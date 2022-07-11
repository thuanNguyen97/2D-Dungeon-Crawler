using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _spiderSprite;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _spiderSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        //if idle is playing
        //do nothing

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    void Movement()
    {
        //if current pos == pointA
        //move right
        //else if current == pointB
        //move left

        if (_currentTarget == pointA.position)
        {
            _spiderSprite.flipX = true;
        }
        else if (_currentTarget == pointB.position)
        {
            _spiderSprite.flipX = false;
        }    

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

        //play idle when reach destination
        //flip sprite

    }
}
