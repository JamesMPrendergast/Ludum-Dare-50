using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float timer;
    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //convert raw seconds into display
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        if (seconds < 10)
        {
            gameObject.GetComponent<Text>().text = minutes + ":0" + seconds;
        } else
        {
            gameObject.GetComponent<Text>().text = minutes + ":" + seconds;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("minutes", minutes);
        PlayerPrefs.SetInt("seconds", seconds);
    }
}
