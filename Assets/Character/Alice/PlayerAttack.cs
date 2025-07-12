using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int Damage;
    public float Time;
    public float StartTime;

    private Animator AttackAni;
    private PolygonCollider2D Blade2D;

    // Start is called before the first frame update
    void Start()
    {
        AttackAni = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Blade2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            AttackAni.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(StartTime);
        Blade2D.enabled = true;
        StartCoroutine(DisableHitBox());
    }

    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(Time);
        Blade2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            KLP klp = collision.gameObject.GetComponent<KLP>();

            collision.GetComponent<Enemy>().TakeDamage(Damage);

            klp.BeHurt = true;
        }
    }
}
