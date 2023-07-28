using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Obejcts on the main menu that need to be hidden when a button is pressed
    public GameObject mainMenuObjects;


    // Taking the normal cursor  function from the button effetc script
    // This is so the cursor will reset when the button is pressed
    public ButtonAudio normalCursor;
    void Awake() {
        normalCursor = FindObjectOfType<ButtonAudio>();
    }

    // Load Game Button
    // when the load game button is pressed in the main menu
    public bool isLoadGameOpen = false; // if the load game menu is currently open
    public GameObject LoadGamePanel;    // The groupd of canvas gameobjects that makes up the load game 'panel'
    public void LoadGame() {    // Runs the function when the button is pressed
        isLoadGameOpen = true;  // the load game menu is open, thus needs to be chaneged to true
        mainMenuObjects.SetActive(false); // This hides the standard ui for the main menu, which includes the title, and other buttons
        LoadGamePanel.SetActive(true);  // This enables the menu of loading the different game saves
        normalCursor.OnButtonExit(); // Resets the cursor to normal so that when the menu is opened it doens't stay on the hand cursor
    }

    public void LoadOne() { // Loads save one
        SceneManager.LoadScene("SampleScene");  
    }

    // New Game Button
    // When the new game button is pressed in the main menu
    public static void NewGame() {
        /*Will Open a menu to choose a save*/  
    }

    // Settings
    // The function that will run when the settings button is clicked/pressed in the main menu
    public bool isSettingsOpen = false; // if the settigns menu is open
    public GameObject settingsPanel;    // the group of canvas gameobjects for the settings menu
    public void Settings() {    // runs when the settings button is pressed
        isSettingsOpen = true;  // the settings menu is now open and thus this needs to be updated
        mainMenuObjects.SetActive(false); // Hides the standard ui
        settingsPanel.SetActive(true);  // enables/shows the settings ui
        normalCursor.OnButtonExit();  // Resets the cursor to normal so that when the menu is opened it doens't stay on the hand cursor
    }

    // return to main menu
    // A button that allows the user to return from either the settings or load game menu to the main menu
    public void Return() {  // runs when the button is pressed
        isSettingsOpen = false; // the settings will not be open
        isLoadGameOpen = false; // the load game menu will not be open; this buttong runs both because this button can be used for both of the menus
        mainMenuObjects.SetActive(true);    // enables the objects of the main menu
        LoadGamePanel.SetActive(false); // Hides the menu for loading the game saves
        settingsPanel.SetActive(false); // hides the settings menu; once more this runs aswell so the button can be used for multiple menus
        normalCursor.OnButtonExit();  // Resets the cursor to normal so that when the menu is opened it doens't stay on the hand cursor
    }

    // Quit Game
    public void QuitGame() {
        Application.Quit(); // Quits the game application
        normalCursor.OnButtonExit();  // Resets the cursor to normal so that when the menu is opened it doens't stay on the hand cursor
    } 
}
