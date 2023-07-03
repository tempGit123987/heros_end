using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_fireballExplosion : MonoBehaviour
{
    public float radius = 5.0f; //radius of explosion
    public float damage = 75f;  //damage the fireball does to the enemies
    public float power = 100.0f; //magnitude of the explosion
    public float bounce = 3.0f;

    void Start()
    {
        //radius = 5.0f;
        //damage = 75f;
        //power = 200f;
    }

    void OnCollisionEnter()
    {
        //creates an array of colliders names colliders adds all colliders in the spheres
        //radius from the position (where the spell hit is the position, ground, enemy, whatever)
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider hit in colliders) //iterates through every collider in the array
        {
    
            //creates a Ribidbody var, rb, and assigns it to the detected collisions Rigidbody
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            MoveToPlayer mtp = hit.GetComponent<MoveToPlayer>();
            if(rb != null) //if a ribidbody DOES exist...
            {
                //add explosion force
                if(hit.gameObject.tag == "Enemy")
                {
                mtp.GotHit();
                rb.AddExplosionForce(power, transform.position, radius, bounce);
                }
            }
            
            //finds every detected collider with a component of enemy_health (script)
            enemy_health eHealth = hit.GetComponent<enemy_health>();
            if(eHealth != null) //if a enemy_health DOES exist...
            {
                //take damage (sending the amount of damage the fireball does)
                eHealth.TakeDamage(damage);
            }
            //destroys the spell because it "hit" a target
            Destroy(gameObject);
        }
    }

    public void IncreaseDamage(float damageMult)
    {
        damage = damage * damageMult;
    }

    public void IncreaseRadius(float rad)
    {
        radius = radius * rad;
    }
}
