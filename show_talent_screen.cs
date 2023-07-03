using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_talent_screen : MonoBehaviour
{

    public GameObject talentScreen;
    private bool isShowing = false;
    public GameObject waveController;
    
    wave_controller gameStateCheck; 

    void Start()
    {
        waveController = GameObject.FindGameObjectWithTag("Wave-Controller");
        gameStateCheck = waveController.GetComponent<wave_controller>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //toggles the talent screen with "T" AND if it is the intermission
        if((Input.GetKeyDown(KeyCode.T)) && ((int)gameStateCheck.currentState == 2))
        {
            if(isShowing)
            {
                LowerTalentScreen();
            } else
            {
                RaiseTalentScreen();
            }
        }

        //lowers the talent screen if it is open when the intermission ends
        if(isShowing && ((int)gameStateCheck.currentState != 2))
        {
            LowerTalentScreen();
        }


    }

    void LowerTalentScreen()
    {
        talentScreen.SetActive(false);
        isShowing = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RaiseTalentScreen()
    {
        talentScreen.SetActive(true);
        isShowing = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Test()
    {
        Debug.Log("accessed");
    }
}
