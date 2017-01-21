using UnityEngine;
using System.Collections;

public class LanguageButton : MonoBehaviour {
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
