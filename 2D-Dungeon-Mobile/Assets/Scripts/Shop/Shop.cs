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

    public void SelectItem(int item)
    {
        //0 = flame sword
        //1 = boots of flight
        //2 = key to castle

        Debug.Log("Item selected" + item);

        //switch between item
        switch(item)
        {
            case 0: //flame sword
                UIManager.Instance.UpdateShopSelection(55);
                break;
            case 1: //boots of flight
                UIManager.Instance.UpdateShopSelection(-41);
                break;
            case 2: //key to the castle
                UIManager.Instance.UpdateShopSelection(-125);
                break;
        }
    }

    //Buy item method
    //check if player's gem is greater or equal to the item price
    //if it is, then got the item. subtract cost from players gem
    //else, cancel sale
}
