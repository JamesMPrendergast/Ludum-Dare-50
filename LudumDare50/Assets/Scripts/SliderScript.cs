using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderScript : MonoBehaviour
{
    //sets a PlayerPref to the slider value

    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("Sensitivity", 35);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Start")) {
            slider.value = 35;
        }
    }

    void Update()
    {
        PlayerPrefs.SetFloat("Sensitivity", slider.value);
    }
}
