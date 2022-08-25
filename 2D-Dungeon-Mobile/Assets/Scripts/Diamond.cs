using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    //OnTriggerEnter to collect it
    //check if that is player
    //add the value of diamond to player


    public int gems = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //add gems with function
                player.AddGem(gems);

                //add diamond amount value to player
                //player.diamonds += gems;

                Destroy(this.gameObject);
            }    
                
        }    
    }
}
