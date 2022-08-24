using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;

    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if (_player != null)
            {
                //send player diamond info to the UIManager
                UIManager.Instance.OpenShop(_player.diamonds);
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
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1: //boots of flight
                UIManager.Instance.UpdateShopSelection(-41);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2: //key to the castle
                UIManager.Instance.UpdateShopSelection(-125);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    //Buy item method
    //check if player's gem is greater or equal to the item price
    //if it is, then got the item. subtract cost from players gem
    //else, cancel sale

    public void BuyItem()
    {
        if (_player.diamonds >= currentItemCost)
        {
            //award item
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToTheCastle = true;
            }    

            //subtract money
            _player.diamonds -= currentItemCost;

            Debug.Log("Purchased " + currentSelectedItem);
        }
        else
        {
            Debug.Log("You do not have enough gem.");
            shopPanel.SetActive(false);
        }    
    }    
}
