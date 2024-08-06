using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public static ScoreManager instance;
    private int score;
    public static int highScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }

    }
    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        UpdateScoreText();
        CheckHighScore();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
        
    }
    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
    }
}
