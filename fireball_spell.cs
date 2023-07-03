using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fireball_spell : MonoBehaviour
{

public float fbDamage = 50.0f;

void Start()
{
    //fbDamage = 50.0f;
}

void OnCollisionEnter(Collision col)
{
    if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boss")
    {
        
        col.gameObject.GetComponent<enemy_health>().TakeDamage(fbDamage);

        Destroy(gameObject);
    }

    Destroy(gameObject);
}
    public void IncreaseDamage(float damageMult)
    {
        fbDamage = fbDamage * damageMult;
    }
}
