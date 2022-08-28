using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    //get handle to rigidbody
    private Rigidbody2D _rigid;

    //variable for amount of diamond
    public int diamonds;

    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private LayerMask _groundedLayer;
    private bool _resetJump = false;
    private bool _grounded = false;

    //handle to animation controller
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordArcSpirte;

    public int Health { get; set;}


    // Start is called before the first frame update
    void Start()
    {
        //assign handle rigidbody
        _rigid = GetComponent<Rigidbody2D>();
        //assign handle animation controller
        _playerAnim = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        // get the second child of the player object
        _swordArcSpirte = transform.GetChild(1).GetComponent<SpriteRenderer>();

        Health = 4;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        //horizontal input for left/right
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");  //crossplatform input  
        _grounded = IsGrounded();

        //flip sprite
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        //current velocity  = new vecotr3(horizontal input, current velocity) --> walk
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("A_Btn")) && IsGrounded())
        {
            _playerAnim.Jump(true);
            Debug.Log("Jump!");

            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            //tell animator to jump
            
            StartCoroutine(ResetJumpRoutine());
            
        }

        _playerAnim.Move(move);

    }

    void Attack()
    {
        if(CrossPlatformInputManager.GetButtonDown("B_Btn") && IsGrounded() == true)
        {
            _playerAnim.Attack();
        }
    }

    bool IsGrounded()
    {
        //1 << 8 is the layer of the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundedLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if (hitInfo.collider != null)
        {
            Debug.Log("Grounded");
            //set jump animator bool to false
            _playerAnim.Jump(false);
            if (_resetJump == false)
                return true;
            
        }
        return false;
    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _sprite.flipX = false;

            _swordArcSpirte.flipX = false;
            _swordArcSpirte.flipY = false;

            Vector3 newPos = _swordArcSpirte.transform.localPosition;
            newPos.x = 0.49f;
            _swordArcSpirte.transform.localPosition = newPos; 
        }
        else if (faceRight == false)
        {
            _sprite.flipX = true;

            _swordArcSpirte.flipX = true;
            _swordArcSpirte.flipY = true;

            Vector3 newPos = _swordArcSpirte.transform.localPosition;
            newPos.x = -0.49f;
            _swordArcSpirte.transform.localPosition = newPos; 
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }

        Debug.Log("Player::Damage()");

        //subtract 1 health
        Health--;
        //update UI
        UIManager.Instance.UpdateLives(Health);
        //check for death
        //play death anim
        if (Health < 1)
        {
            _playerAnim.Dead();
        }

    }    

    //update gem count
    public void AddGem(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }
}
