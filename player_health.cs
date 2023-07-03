using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    public float pHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pHealth <= 0)
        {
            //code to lose game
            Debug.Log("you died");
        }
    }

    public void TakeDamage(float damage)
    {
        pHealth = pHealth - damage;
    }
}
