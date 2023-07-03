using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fireball : MonoBehaviour
{

    //damage of enemy fireball spell
    public float enemyFireballDamage = 35.0f;

    //Unity fucntion for an object colliding with another object
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player") //if the object it hits is named player...
        {
            //apply the damage to the player
            col.gameObject.GetComponent<player_health>().TakeDamage(enemyFireballDamage);
            //and then destroy the fireball
            Destroy(gameObject);
        }
        
        //this would be to destroy the fireball if it hits anything at all
        Destroy(gameObject);
    }
}



