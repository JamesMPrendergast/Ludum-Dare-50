using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InevitabilityBar : MonoBehaviour
{
    public static InevitabilityBar current;
    public Slider slider;


    public void Start()
    {
        current = this;
    }

    public void Update()
    {
        if (slider.value <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    //changes inevitability bar
    public void ChangeInevitability (float change)
    {
        slider.value += change;
        Mathf.Clamp(slider.value, 0.0f, 100.0f);
    }
}
