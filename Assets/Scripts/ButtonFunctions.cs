using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour {

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeLanguage()
    {
        if (GameManager.instance.currentLanguage == "English")
        {
            GameManager.instance.ApplyLanguage(Language.Portuguese);
        }
        else
        {
            GameManager.instance.ApplyLanguage(Language.English);
        }
    }
}
