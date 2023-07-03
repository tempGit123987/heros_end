using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD_test : MonoBehaviour
{

    //add comments!!!

    private TextMeshProUGUI hudText;
    private GameObject wave_controller;
    private GameObject player;


    public GameObject[] spawners;
    public static int totalNumOfEnemies;
    public static int currentNumOfEnemies;


    private bool hasSetNumOfEnemies = false;

    player_health _playerHealth;
    wave_controller waveNum, gameStateCheck, waveTimer, tPoints;
    // Start is called before the first frame update
    void Start()
    {
        hudText = GetComponent<TextMeshProUGUI>();
        wave_controller = GameObject.FindGameObjectWithTag("Wave-Controller");
        waveNum = wave_controller.GetComponent<wave_controller>();
        gameStateCheck = wave_controller.GetComponent<wave_controller>();
        waveTimer = wave_controller.GetComponent<wave_controller>();
        tPoints = wave_controller.GetComponent<wave_controller>();
        player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = player.GetComponent<player_health>();
    }

    // Update is called once per frame
    void Update()
    {
        //totalNumOfEnemies = spawners[0].GetComponent<spawn_enemy>().numOfEnemies + spawners[1].GetComponent<spawn_enemy>().numOfEnemies;
        if(((int)gameStateCheck.currentState == 1) && hasSetNumOfEnemies == false)
        {   
            SetTotalNumOfEnemies();
            hasSetNumOfEnemies = true;
        }
        if((int)gameStateCheck.currentState == 2)
        {
            hasSetNumOfEnemies = false;
            hudText.SetText("Health: {0}, Talent Points: {1}, Time till next wave: {2:0}", _playerHealth.pHealth, tPoints.talentPoints, waveTimer.betweenWaveTimer); // shows time left in whole numbers
        }        
        else
        {
            hudText.SetText("Health: {0}, Current wave: {1}, Enemies Remaining: {2}", _playerHealth.pHealth, waveNum.waveNumber, totalNumOfEnemies); //displays current wave and num of enemies left
        }
        
 
    }

    void SetTotalNumOfEnemies()
    {
        totalNumOfEnemies = spawners[0].GetComponent<spawn_enemy>().numOfEnemies + spawners[1].GetComponent<spawn_enemy>().numOfEnemies + spawners[2].GetComponent<spawn_enemy>().numOfEnemies + spawners[3].GetComponent<spawn_enemy>().numOfEnemies;   
    }
}
