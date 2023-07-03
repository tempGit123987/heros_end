using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{

    //add comments!!!

    
    public float eHealth = 100.0f;
    public enemy_health_bar eHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "Enemy")
        {
            eHealth = 100.0f;
        }
        if(this.gameObject.tag == "Boss")
        {
            eHealth = 250.0f;
        }
        eHealthBar.SetMaxHealth(eHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        eHealth = eHealth - damage;
        eHealthBar.SetHealth(eHealth);
        if(eHealth <= 0)
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
