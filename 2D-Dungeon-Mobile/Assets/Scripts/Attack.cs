using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //variable to determine if the damage function can be called
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Hit: " + other.name);
        
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            //if can attack
            if (_canDamage == true)
            {
                hit.Damage();
                //set that variable to false 
                _canDamage = false;
                StartCoroutine(resetDamage());
            }    
           
        }

    }

    //coroutine to reset the variable after 0.5f
    IEnumerator resetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true; 
    }    
}
