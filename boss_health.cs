using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    //add comments!!!

    
    public float eBossHealth = 250.0f;
    public enemy_health_bar eBossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        eBossHealthBar.SetMaxHealth(eBossHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        eBossHealth = eBossHealth - damage;
        eBossHealthBar.SetHealth(eBossHealth);
        if(eBossHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        HUD_test.totalNumOfEnemies--;
        Destroy(gameObject);
    }
}
