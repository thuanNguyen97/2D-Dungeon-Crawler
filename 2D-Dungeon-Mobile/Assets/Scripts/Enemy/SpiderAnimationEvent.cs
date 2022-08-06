using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    //handle to the spider
    private Spider _spider;

    public void Start()
    {
        //assign handle to the spider
        _spider = transform.parent.GetComponent<Spider>();
    }

    public void Fire()
    {
        //tell spider to fire
        Debug.Log("Spider should fire");
        //use handle to call attack method on the spider
        _spider.Attack();
    }
}
