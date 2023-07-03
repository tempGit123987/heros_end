using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chain_lightning : MonoBehaviour
{
    public Camera fpsCam; //the camera (where the lightening comes from)

    public float damage = 20f; //base damage
    public float attackRange = 100f; //base attack range
    public float chainLightningRange = 5f; //how far the chainlighning can hit something else

    public float fireRate = 2.0f; //how fast you can fire chainlightning

    private float nextTimeToFire = 0f; //var used with fireRate for fire rate

    private bool chainLightningTalent = false; //var used to tell if the talent has been unlocked

    // Update is called once per frame
    void Update()
    {
        //if fire button, AND can enough time has passed AND talen is purchased
        if(Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextTimeToFire && chainLightningTalent == true)
        {
            //reset the time for when it can be fired
            nextTimeToFire = Time.time + 1f/fireRate;
            //call function to shoot chain lightening
            ShootChainLightning();
        }
    }

    void ShootChainLightning()
    {
        RaycastHit hit; //creates a raycasthit named hit

        //does internal math, fires the ray from the camera position, straight out, then collects
        //data on what it hits, and has a range (attackRange) of the laser
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, attackRange))
        {
            //if the item the laser hit is tagged as an enemy...
            if(hit.collider.tag == "Enemy" || hit.collider.tag == "Boss")
            {
                //creates an array of colliders (named colliders) at the point of impact. all of these
                //colliders are found by using Physics.OverlapSphere with the position and range of
                //chainlightning (a cicrcle is made with a radius of chainLightningRange, at point of impact
                //then all the things within that sphere with a collider are added to the array.
                Collider[] colliders = Physics.OverlapSphere(hit.transform.position, chainLightningRange);
                
                //for all the colliders in that...
                foreach(Collider col in colliders)
                {
                    //create an enemy_health scrip reference named enemy...
                    enemy_health enemy = col.GetComponent<enemy_health>();
                    if(enemy != null) //and if that is not null (so it found the script)...
                    {
                        enemy.TakeDamage(damage); //apply the damage to the enemy
                    }


                //NOTE:
                //if mana is added, make it to where the number of enemies hit
                //affects how much mana is used
                }
                

            }
        }
    }

    //this fucntion is used to increase the range of the sphere of chain lightning
    public void IncreaseRange(float rangeMult)
    {
        chainLightningRange = chainLightningRange * rangeMult;
    }

    //this funciton is used to activate the spell
    public void ActivateChainLightning()
    {
        chainLightningTalent = true;
    }
}

