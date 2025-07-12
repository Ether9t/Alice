using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;

    private Animator PlayerDeath;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerDeath = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int EnemyDamage)
    {
        Health -= EnemyDamage;
        if (Health < 0)
        {
            Health = 0;
        }
        HealthBar.HP = Health;
        if (Health <= 0)
        {
            PlayerDeath.SetTrigger("Death");
            Invoke("Restart", 0.6f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
