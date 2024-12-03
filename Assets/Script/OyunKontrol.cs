using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private int score = 0;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        GuncelleHighScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("points"))
        {
            score++;
            GuncelleScoreText();

            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
                GuncelleHighScoreText();
            }
        }
    }

    void GuncelleScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void GuncelleHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore;
    }
}
