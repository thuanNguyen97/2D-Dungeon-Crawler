using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;

    public int Health { get; set;}

    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public void Damage()
    {
        if (isDead == true)
            return;

        Health--;
        if (Health < 1)
        {
            

            isDead = true;
            //play death animation
            anim.SetTrigger("Death");
            //Destroy(this.gameObject);

            //spawn diamonds (casting)
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //change the value whatever my gem count is
            diamond.GetComponent<Diamond>().gems = base.gems;
        }    
    }

    public override void Movement()
    {
        //sit still
    }

    public void Attack()
    {
        //instantiate acid effect
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
