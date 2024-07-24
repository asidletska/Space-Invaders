using UnityEngine;

public class Audio : MonoBehaviour
{
    public void MuteHandler(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
            PlayerPrefs.Save();
        }
        else if (!mute) 
        {
            AudioListener.volume = 1;
            PlayerPrefs.Save();
        }
    }
}
