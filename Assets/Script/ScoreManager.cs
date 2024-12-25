using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private ObjectPool objectPool;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }
    
    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
        objectPool.ResetPosCylinder();
    }
    public void UpdateHighScoreText()
    {
        highScoreText.text = "HighScore : " + highScore;
    }
}