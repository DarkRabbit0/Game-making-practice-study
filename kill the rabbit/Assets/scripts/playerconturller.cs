using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerconturller : MonoBehaviour
{

    public float runSpeed = 3;
    public float jumpSpeed = 4;
    public float doubleJumpspeed = 3.3f;
    public byte jumpNumber = 2;

    private Rigidbody2D my_rigidybody;
    private Animator my_ahim;
    private BoxCollider2D my_feet;
    private bool is_ground;
    private byte more_jump;
    private bool down_grounded_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        my_rigidybody = GetComponent<Rigidbody2D>();
        my_ahim = GetComponent<Animator>();
        my_feet = GetComponent<BoxCollider2D>();
        my_ahim.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Jump();
        CheckGrounded();
        DownGrounded();
    }

    void CheckGrounded()
    {
        is_ground = my_feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if(is_ground)
        {
            my_ahim.SetBool("isground", true);
        }
        else{
            my_ahim.SetBool("isground", false);
        }

//        Debug.Log(is_ground);//调试信息
//        Debug.Log((my_ahim.GetBool("Jump")));//调试信息

    }

    void DownGrounded()
    {
        if(my_ahim.GetBool("Jump") && my_rigidybody.velocity.y<0.0f)
        {
           down_grounded_flag = true;
        }
        if (is_ground && down_grounded_flag)
        {
            down_grounded_flag = false;
            my_ahim.SetBool("Jump", false);
            my_ahim.SetBool("Idle", true);
        }
    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(my_rigidybody.velocity.x) > Mathf.Epsilon;
        if(playerHasXAxisSpeed)
        {
            if(my_rigidybody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (my_rigidybody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

        }
    }

    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, my_rigidybody.velocity.y);
        my_rigidybody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(my_rigidybody.velocity.x) > Mathf.Epsilon;
        my_ahim.SetBool("Run", playerHasXAxisSpeed);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(is_ground)
            {
                my_ahim.SetBool("Idle", false);
                my_ahim.SetBool("Jump", true);
                more_jump = jumpNumber;
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                my_rigidybody.velocity = Vector2.up * jumpVel;
            }
            else if(more_jump> 0)
            {
                more_jump--;
                Vector2 doubleJumpVel = new Vector2(0.0f,doubleJumpspeed);
                my_rigidybody.velocity = Vector2.up*doubleJumpVel;
            }
        }
    }



}
