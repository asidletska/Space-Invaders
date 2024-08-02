using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameOverPanel;
    public void OnContinueHandler()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartHandler()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
