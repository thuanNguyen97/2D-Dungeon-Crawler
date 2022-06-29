using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //get handle to rigidbody
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        //assign handle rigidbody
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal input for left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal");    

        //current velocity  = new vecotr3(horizontal input, current velocity)
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);
    }
}
