using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject panel;
    public GameManager manager;
    public void PauseButtonPressed()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MenuButtonPressed()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

}
