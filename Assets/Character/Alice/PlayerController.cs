using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Alice;
    public float Speed;
    public float JumpForce;
    public float DoubleJumpForce;

    public int EnemyDamage;

    private Animator AliceAni;
    private BoxCollider2D AliceJump;
    private bool IsGround;
    private bool CanDoubleJump;
    private PlayerHealth PlayerHP;

    void Start()
    {
        Alice = GetComponent<Rigidbody2D>();
        AliceAni = GetComponent<Animator>();
        AliceJump = GetComponent<BoxCollider2D>();
        PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        CheckGround();
        SwitchAliceAni();
    }

    void CheckGround()
    {
        IsGround = AliceJump.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(IsGround);
    }

    void PlayerMovement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        if (horizontalmove != 0)
        {
            Alice.velocity = new Vector2(horizontalmove * Speed , Alice.velocity.y); 
        }
        if (facedirection != 0) 
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(IsGround)
            {
                AliceAni.SetBool("Jump", true);
                Alice.velocity = new Vector2(Alice.velocity.x, JumpForce);
                CanDoubleJump = true;
            }
            else
            {
                if(CanDoubleJump)
                {
                    AliceAni.SetBool("DoubleJump", true);
                    Vector2 DoubleJumpV = new Vector2(0.0f, DoubleJumpForce);
                    Alice.velocity = Vector2.up * DoubleJumpForce;
                    CanDoubleJump = false;
                }
            }
        }

        bool PlayerHasXAxisSpeed = Mathf.Abs(Alice.velocity.x) > Mathf.Epsilon;
        AliceAni.SetBool("Run", PlayerHasXAxisSpeed);
    }


    void SwitchAliceAni()
    {
        AliceAni.SetBool("Idle", false);
        if (AliceAni.GetBool("Jump")) 
        {
            if (Alice.velocity.y < 0.0f)
            {
                AliceAni.SetBool("Jump", false);
                AliceAni.SetBool("Fall", true);
            }
        }
        else if(IsGround)
        {
            AliceAni.SetBool("Fall", false);
            AliceAni.SetBool("Idle", true);
        }

        if (AliceAni.GetBool("DoubleJump"))
        {
            if (Alice.velocity.y < 0.0f)
            {
                AliceAni.SetBool("DoubleJump", false);
                AliceAni.SetBool("DoubleFall", true);
            }
        }
        else if (IsGround)
        {
            AliceAni.SetBool("DoubleFall", false);
            AliceAni.SetBool("Idle", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (PlayerHP != null)
            {
                PlayerHP.DamagePlayer(EnemyDamage);
                AliceAni.SetTrigger("Hurt");
            }
        }
    }
}
