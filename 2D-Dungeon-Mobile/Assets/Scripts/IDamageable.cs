using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    //porperties
    int Health { get; set;}

    void Damage();
}
