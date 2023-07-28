using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fov : MonoBehaviour
{
    public Camera _camera;

    public Slider slider;

    void Start()
    {
        if(!PlayerPrefs.HasKey("Fov"))
        {
            PlayerPrefs.SetFloat("Fov", 0.7f);
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
        _camera.GetComponent<Camera>().orthographicSize = (slider.value);
        Save();
    }

    public void Load()
    {
        slider.value = PlayerPrefs.GetFloat("Fov");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Fov", slider.value);
    }
}
