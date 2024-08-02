using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameObject panel;
    public void OnContinueClick()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
