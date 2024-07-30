using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public GameObject panel;
    public void OnContinueHandler()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
    public void RestartHandler()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
    }
}
