using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResolution : MonoBehaviour
{
    public int[] width = new int[] {1920, 1600, 1366, 1280, 800};
    public int[] height = new int[] { 1080, 900, 768, 720, 600};  

    public Dropdown resDropdown;
    public Dropdown fullScreen;

    private void Start() {
        Load();
    }

    private void Update() {
        Screen.SetResolution(width[resDropdown.value], height[resDropdown.value], fullscreen());
        Save();
    }

    public bool fullscreen() {
        if (fullScreen.value == 0) {
            return true;
        } else {
            return false;
        }
    }

    private void Load()
    {
        resDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Resolution");
        fullScreen.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Fullscreen");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Resolution", resDropdown.GetComponent<Dropdown>().value);
        PlayerPrefs.SetInt("Fullscreen", fullScreen.GetComponent<Dropdown>().value);
    }
}
