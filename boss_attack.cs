using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_attack : MonoBehaviour
{
 public float bossDamage = 45f;
    public float timeToAttack = 1.0f;
    private float nextAttackTime = 0f;

    private Transform player;
    private GameObject playerLoc;

    private float distance;

    player_health playerHealthScript;
    
    

    void Start()
    {
        
        playerLoc = GameObject.Find("Player");
        if(player == null)
        {
        player = playerLoc.transform;
        }

        playerHealthScript = player.GetComponent<player_health>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, this.transform.position);

        if(distance < 3 && Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + 1f/timeToAttack;
            EnemyMeleeAttack();
        }
    }


    
    void EnemyMeleeAttack()
    {
        if(playerHealthScript != null)
        {
        playerHealthScript.TakeDamage(bossDamage);
        }
    }
    
}
