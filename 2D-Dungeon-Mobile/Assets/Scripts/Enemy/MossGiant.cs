using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    //properties
    public int Health { get; set;}

    //use for initialization
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();

        float distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);

        //Debug.Log("Distance: " + distance);

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        //Debug.Log("Side: " + direction.x);

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            //face right
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            //face left
            sprite.flipX = true;
        }
    }

    public void Damage()
    {
        Debug.Log("MossGiant::Damage!");

        //subtract 1 from health
        Health--;

        //trigger hit anim
        anim.SetTrigger("Hit");

        isHit = true;

        anim.SetBool("InCombat", true);

        //if health less than 1
        if (Health < 1)
        {
            //destroy
            Destroy(this.gameObject);
        }
    }
}
