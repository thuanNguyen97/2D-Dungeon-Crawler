using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //send player diamond info to the UIManager
                UIManager.Instance.OpenShop(player.diamonds);
            }    

            shopPanel.SetActive(true);
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }    
    }

    public void SelectItem()
    {
        Debug.Log("Item selected");
    }
}
