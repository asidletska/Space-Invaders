using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreLabel;

    public static int highScore;
    public static int points = 0;

    void Start()
    {
        scoreLabel = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("highscore", highScore);
    }

    void Update()
    {
        scoreLabel.text = "Score: " + points.ToString();

        if (points > highScore)
        {
            PlayerPrefs.SetInt("highscore", points);
        }
    }
}
