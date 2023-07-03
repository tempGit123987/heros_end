using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{

    public GameObject enemyPrefab; //the enemy prefab
    public float timeToNextSpawn; //elapsed time
    public float spawnTimer = 3; //seconds between spawn

    public int numOfEnemies; //base number of enemies to spawn (changed later)
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextSpawn = timeToNextSpawn + Time.deltaTime; //calculates the time until the next enemy can spawn

        //if the calculated time to spawn is greater than the spawn timer AND the num of enemies is NOT zero...
        if((timeToNextSpawn > spawnTimer) && (numOfEnemies != 0))
        {
            //create an enemy
            GameObject instEnemy = Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
            numOfEnemies--; //reduce the num of enemies by 1
            timeToNextSpawn = 0; //reset the time before the next spawn
        }

        //if the number of enemies (FOR THIS SPAWNPOINT) reaches zero, set this spawnpoint to inactive
        if(numOfEnemies == 0)
        {
            gameObject.SetActive(false);
        }
    }

    //function gets called when "wave_controller" script starts a new wave
    //calculates the amount of enemies to spawn with a random range
    public void SetNumOfEnemies(int waveNumber)
    {
        numOfEnemies = (Random.Range(waveNumber, waveNumber * 2)) + 2;
        Debug.Log(numOfEnemies);
    }

    public void SpecialSetNumOfEnemies(int waveNumber)
    {
        numOfEnemies = waveNumber;
    }
}
