using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set;}

    public override void Init()
    {
        base.Init();
        //assign Health property to our enemy health
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
            return;

        Debug.Log("Damage!");

        //subtract 1 from health
        Health--;

        //trigger hit anim
        anim.SetTrigger("Hit");

        isHit = true;

        anim.SetBool("InCombat", true);

        //if health less than 1
        if (Health < 1)
        {
            

            isDead = true;
            //play death animation
            anim.SetTrigger("Death");
            //destroy
            //Destroy(this.gameObject);

            //spawn diamonds (casting)
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //change the value whatever my gem count is
            diamond.GetComponent<Diamond>().gems = base.gems;
        }    
    }
}
