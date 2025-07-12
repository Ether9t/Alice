using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int EnemyHealth;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }
    
    public void TakeDamage(int Damage)
    {
        EnemyHealth -= Damage;
    }
}
