using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    int minutes, seconds;
    public Text highscoreText;
    int highscoreMinutes, highscoreSeconds;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        minutes = PlayerPrefs.GetInt("minutes", 0);
        seconds = PlayerPrefs.GetInt("seconds", 0);

        gameObject.GetComponent<Text>().text = minutes + ":" + seconds;

        highscoreMinutes = PlayerPrefs.GetInt("highscoreMinutes", 0);
        highscoreSeconds = PlayerPrefs.GetInt("highscoreSeconds", 0);

        float score = minutes * 60 + seconds;
        float highScore = highscoreMinutes * 60 + highscoreSeconds;

        PlayerPrefs.DeleteAll();

        if (score > highScore) {
            highscoreText.text = "New highscore!";
            PlayerPrefs.SetInt("highscoreMinutes", minutes);
            PlayerPrefs.SetInt("highscoreSeconds", seconds);
        }
        else {
            highscoreText.text = "Highscore: " + highscoreMinutes + ":" + highscoreSeconds;
            PlayerPrefs.SetInt("highscoreMinutes", highscoreMinutes);
            PlayerPrefs.SetInt("highscoreSeconds", highscoreSeconds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
