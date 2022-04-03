using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    int minutes, seconds;

    // Start is called before the first frame update
    void Start()
    {
        minutes = PlayerPrefs.GetInt("minutes", 0);
        seconds = PlayerPrefs.GetInt("seconds", 0);

        gameObject.GetComponent<Text>().text = "You survived for " + minutes + " minute(s) and " + seconds + " second(s)!";
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
