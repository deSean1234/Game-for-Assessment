using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // If the game is paused
    public bool isGamePaused = false;

    // Pause Menu UI
    public GameObject pauseMenuUI;
    
    // Achievments UI
    public GameObject achievmentsUI;
    // if the achievements ui is open
    bool isTrophiesOpen = false;

    // Settings
    public GameObject settingsUI;
    bool isSettingsOpen = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && CanPause()) {
            if (isTrophiesOpen) {
                achievmentsUI.SetActive(false);
                isTrophiesOpen = false;
                pauseMenuUI.SetActive(true);
            } else if (isSettingsOpen) {
                settingsUI.SetActive(false);
                isSettingsOpen = false;
                pauseMenuUI.SetActive(true);
            } else if (isGamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isGamePaused = !isGamePaused;
    }

    public void Resume() {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isGamePaused = !isGamePaused;
    }

    public void TrophiesUI() {
        achievmentsUI.SetActive(true);
        isTrophiesOpen = true;
        pauseMenuUI.SetActive(false);
    }

    public void SettingsUI() {
        settingsUI.SetActive(true);
        isSettingsOpen = true;
        pauseMenuUI.SetActive(false); 
    }

    public void QuitToMenu() {
        Resume();    // Because techically the game is no longer paused the game needs to be resumed
        SceneManager.LoadScene("MainMenu");
    }

    bool CanPause() {   // A function that checks if a contrasting gameobject is active to see if the pause meu can be opened
        try {
            GameObject pm = GameObject.Find("Inventory");   // tries to find the pause menu ui
            if (pm.activeInHierarchy) {}    // I have zero idea what this line does, but if I delete it the function doesn't work properly
            return false;   // the pause menu must be open and so the user cannot open their inventory
        } catch {   // because it becomes null the if statement fails and so it runs the catch block
            return true;    // the inventory is not open and so the pause menu can be openned
        }
    }
}
