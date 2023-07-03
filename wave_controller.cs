using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_controller : MonoBehaviour
{

    public int waveNumber = 0; //wave number
    public GameObject[] spawnpoints; //array of spawnpoints for enemies on the map

    //controller for which state the game is in: currently in a wave, start of a wave, inbetween waves
    public enum GameState {START_NEXT_WAVE = 0, WAVE_IN_PROGRESS = 1, INTERMISSION = 2};
    public GameState currentState; //the current state of the game

    public float betweenWaveTimer = 10; //seconds between each wave

    //considered obsolete as of Feb 23, 2021
    //private bool allInactive = false; //bool to see if all the spawnpoints have been deactivated

    public bool allDead = false; // bool for checking if all the enemies are dead
    private GameObject tempEnemy;

    public int talentPoints = 0;

    public GameObject eventSystem;

    show_talent_screen endWaveTalentScreen;
    spawn_enemy spawnEnemy;


    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.START_NEXT_WAVE; //sets the gamestate to begin a wave
        endWaveTalentScreen = eventSystem.GetComponent<show_talent_screen>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the gamestate is between waves, count a timer down
        if(currentState == GameState.INTERMISSION)
        {
            betweenWaveTimer = betweenWaveTimer - Time.deltaTime;
        }
        
        //if the countdown timer (above) hits zero, set the game state to start the next wave
        //and reset the timer
        if(betweenWaveTimer < 0)
        {            
            currentState = GameState.START_NEXT_WAVE;
            betweenWaveTimer = 10;
        }

        //if the current state of the game is wave in progress
        //check to see if all the spawnpoints in the array are active or not
        //(in other words if they are spawning enemies)
        //NOTE: UPDATE TO WHERE IT ALSO CHECKS IF THERE ARE ENEMIES ON THE MAP
        //AS IT CURRENTLY IS, IT ENTERS THIS PHASE THE MOMENT THE LAST ENEMY IS SPAWNED
        if(currentState == GameState.WAVE_IN_PROGRESS)
        {
            /*
            considered obsolete as of Feb 23, 2021
            for(int i = 0; i < spawnpoints.Length; i++)
            {
                if(spawnpoints[i].activeInHierarchy)
                {
                    allInactive = false;
                    break;
                }
                else
                {
                    allInactive = true;
                    AllDead();
                }
            }
            */
            if(HUD_test.totalNumOfEnemies == 0 && currentState == GameState.WAVE_IN_PROGRESS)
            {
                currentState = GameState.INTERMISSION;
                endWaveTalentScreen.RaiseTalentScreen();
            }
        }

        //if the current state of the game is to start a next wave, it runs the function to do so
        if(currentState == GameState.START_NEXT_WAVE)
        {
            StartWave();
            Debug.Log(waveNumber);
        }

        //checks to see if all the spawnpoints are inactive
        //NOTE: THE ABOVE NOTE ABOUT ENEMIES ON MAP MIGHT BE GOOD HERE INSTEAD
        /*
        BUGS:
        1) IF NO ENEMIES ARE ALIVE BUT THE SPAWNER IS STILL ACTIVE, IT WILL TRIGGER
        THE INTERMISSION STATE, THERFORE PUSHING THE NEXT WAVE WITHOUT PROPER TIME
        IF ENEMIES ARE PLACED IN A WAY THEY CAN'T DIE BEFORE THAT HAPPENS, IT IS AVOIDABLE
        FIX IF NEED
        */


        
        /*
        considered obsolete as of Feb 23, 2021
        if((allInactive == true) && (allDead == true))
        {
            currentState = GameState.INTERMISSION;
            endWaveTalentScreen.RaiseTalentScreen();
            allDead = false;
        }
        */
    }

    void AllDead()
    {
        tempEnemy = GameObject.FindGameObjectWithTag("Enemy");
        if(tempEnemy == null)
        {
            Debug.Log(allDead);
            allDead = true;
        }
    }

    //set up the wave
    void StartWave(){
        waveNumber++; //adds one to the wave number
        talentPoints++; //adds one to talentPoints for talents

        //makes sure the bool checking for inactive spawnpoints is reset so it doesn't accidentely
        //trigger the state of intermission
        //allInactive = false;
        //a foreach loop that checks every spawnpoint in the array
        //first it sets them as active
        //second it gets that spawnpoints "spawn_enemy" script
        //last it calls the SetNumOfEnemies function on that script, passing it the current wave number.
        
        /*
        foreach(GameObject spawn in spawnpoints)
        {
            spawn.SetActive(true);
            spawn_enemy spawnEnemy = spawn.GetComponent<spawn_enemy>();
            spawnEnemy.SetNumOfEnemies(waveNumber);
        }
        */

        //The below code controls which spawn points are active for whice wave.
        //currently wave 1 and 2 are just melee waves,
        //3 is a ranged only, 4 is mixed, and 5 is boss
        //after that it should be able to have mixed everywave
        //and every 5 waves add a boss in there.
        if(waveNumber == 1 || waveNumber == 2)
        {
            for(int i = 0; i < 2; i++)
            {
                spawnpoints[i].SetActive(true);
                spawnEnemy = spawnpoints[i].GetComponent<spawn_enemy>();
                spawnEnemy.SetNumOfEnemies(waveNumber);
            }
        }

        if(waveNumber == 3)
        {
            spawnpoints[2].SetActive(true);
            spawnEnemy = spawnpoints[2].GetComponent<spawn_enemy>();
            spawnEnemy.SetNumOfEnemies(waveNumber);
        }

        if(waveNumber == 4)
        {
            for(int i = 0; i < 3; i++)
            {
                spawnpoints[i].SetActive(true);
                spawnEnemy = spawnpoints[i].GetComponent<spawn_enemy>();
                spawnEnemy.SetNumOfEnemies(waveNumber);
            }
        }

        if(waveNumber % 5 == 0 && waveNumber >= 5)
        {
            spawnpoints[3].SetActive(true);
            spawnEnemy = spawnpoints[3].GetComponent<spawn_enemy>();
            spawnEnemy.SpecialSetNumOfEnemies(1);
        }

        if(waveNumber > 5)
        {
            for(int i = 0; i < 3; i++)
            {
                spawnpoints[i].SetActive(true);
                spawnEnemy = spawnpoints[i].GetComponent<spawn_enemy>();
                spawnEnemy.SetNumOfEnemies(waveNumber);
            }
        }

        currentState = GameState.WAVE_IN_PROGRESS; // sets game's state to wave in progress
    }


}
