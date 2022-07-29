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

    public void Damage()
    {
        Debug.Log("Damage!");

        //subtract 1 from health
        Health--;

        //if health less than 1
        if (Health < 1)
        {
            //destroy
            Destroy(this.gameObject);
        }    
    }
}
