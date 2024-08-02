using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreLabel;

    void Start()
    {
        highScoreLabel = GetComponent<Text>();
        highScoreLabel.text = "HighScore: " + PlayerPrefs.GetInt("highscore", ScoreManager.highScore).ToString();
    }

    void Update()
    {
       //FindObjectOfType<ScoreManager>().UpdateHighScoreText();
       highScoreLabel.text = "HighScore: " + PlayerPrefs.GetInt("highscore", ScoreManager.highScore).ToString();       
    }
}
