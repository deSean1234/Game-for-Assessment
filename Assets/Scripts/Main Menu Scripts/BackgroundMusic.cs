using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public Toggle toggle;
    public AudioSource audioSource;


    void Start()
    {
        if(!PlayerPrefs.HasKey("musicToggle"))
        {
            PlayerPrefs.SetInt("musicToggle", toggle.isOn ? 1 : 0);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = (toggle.isOn ? 1 : 0);
        Save();
    }

    public void Load()
    {
        toggle.isOn = PlayerPrefs.GetInt("musicToggle") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("musicToggle", toggle.isOn ? 1 : 0);
    }
}
