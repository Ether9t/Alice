using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLP : Enemy
{
    public Transform LeftPoint;
    public Transform RightPoint;
    public float KLPSpeed;
    public bool BeHurt = false;

    private Rigidbody2D KLPBody;
    private Animator KLPAni;
    private bool FaceLeft = true;
    private float LeftPos;
    private float RightPos;

    // Start is called before the first frame update
    public void Start()
    {
        KLPBody = GetComponent<Rigidbody2D>();
        KLPAni = GetComponent<Animator>();
        LeftPos = LeftPoint.position.x;
        RightPos = RightPoint.position.x;
        Destroy(LeftPoint.gameObject);
        Destroy(RightPoint.gameObject);
    }

    // Update is called once per frame
    public void Update()
    {
        KLPMovement();
        while(BeHurt)
        {
            KLPAni.SetTrigger("KLPHurt");
            BeHurt = false;
        }
        if (EnemyHealth <= 0)
        {
            KLPAni.SetTrigger("KLPDeath");
        }
        base.Update();
    }

    void KLPMovement()
    {
        if (FaceLeft)
        {
            KLPBody.velocity = new Vector2(-KLPSpeed, KLPBody.velocity.y);
            if (transform.position.x < LeftPos)
            {
                transform.localScale = new Vector3((float)-0.75, (float)0.75, 1);
                FaceLeft = false;
            }
        }
        else
        {
            KLPBody.velocity = new Vector2(KLPSpeed, KLPBody.velocity.y);
            if (transform.position.x > RightPos)
            {
                transform.localScale = new Vector3((float)0.75, (float)0.75, 1);
                FaceLeft = true;
            }

        }
    }

    void KLPDestory()
    {
        Destroy(gameObject);
        EnergyBar.Energy += 1;
    }
}
