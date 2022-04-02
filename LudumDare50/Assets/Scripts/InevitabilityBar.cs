using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InevitabilityBar : MonoBehaviour
{
    public static InevitabilityBar current;

    public void Start()
    {
        current = this;
    }

    public Slider slider;

    //changes inevitability bar
    public void ChangeInevitability (float change)
    {
        slider.value += change;
        Mathf.Clamp(slider.value, 0.0f, 100.0f);
    }
}
