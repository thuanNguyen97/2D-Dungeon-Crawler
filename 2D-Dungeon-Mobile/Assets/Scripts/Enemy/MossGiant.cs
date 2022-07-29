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

       public void Damage()
    {
        
    }
}
