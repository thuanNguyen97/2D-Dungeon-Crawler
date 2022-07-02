using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //get handle to rigidbody
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private float _speed = 5.0f;

    private bool _resetJump = false;
    private bool _grounded = false;

    //handle to animation controller
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        //assign handle rigidbody
        _rigid = GetComponent<Rigidbody2D>();
        //assign handle animation controller
        _playerAnim = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        //horizontal input for left/right
        float move = Input.GetAxisRaw("Horizontal");    
        _grounded = IsGrounded();

        //flip sprite
        if (move > 0)
        {
            _sprite.flipX = false;

        }
        else if (move < 0)
        {
            _sprite.flipX = true;
        }

        //current velocity  = new vecotr3(horizontal input, current velocity) --> walk
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("Jump!");

            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            //tell animator to jump
            _playerAnim.Jump(true);
            StartCoroutine(ResetJumpRoutine());
        }

        _playerAnim.Move(move);

    }

    bool IsGrounded()
    {
        //1 << 8 is the layer of the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);

        if (hitInfo.collider != null)
        {
            Debug.Log("Grounded");
            if (_resetJump == false)
                return true;
            //set jump animator bool to false
            _playerAnim.Jump(false);
        }
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
