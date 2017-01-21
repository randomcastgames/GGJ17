using UnityEngine;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

public enum Language
{
    Portuguese,
    English
}

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public string currentLanguage = "Portuguese";
    XmlDocument currentLanguageDocument;

    public List<TranslatableObject> translatableObjectsList = new List<TranslatableObject>();

    void OnEnable()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if(PlayerPrefs.GetString("Language") != "")
            currentLanguage = PlayerPrefs.GetString("Language");

        instance = this;

        LoadLanguageDocument();
    }

    public void LoadLanguageDocument()
    {
        // Carrega o Xml como texto
        TextAsset documentText = (TextAsset)Resources.Load("Languages/" + currentLanguage);

        // Transforma o texto em Xml
        currentLanguageDocument = new XmlDocument();
        currentLanguageDocument.LoadXml(documentText.ToString());
    }

    public void ApplyLanguage(Language targetLanguage)
    {
        if (targetLanguage == Language.English)
        {
            currentLanguage = "English";
        }
        else if (targetLanguage == Language.Portuguese)
        {
            currentLanguage = "Portuguese";
        }

        PlayerPrefs.SetString("Language", currentLanguage);

        LoadLanguageDocument();

        // Atualiza o termo
        foreach (TranslatableObject currentObject in translatableObjectsList)
        {
            currentObject.ApplyTerm();
        }
    }

    public string FindTerm(string nodeName)
    {
        foreach (XmlNode term in currentLanguageDocument["LanguageData"])
        {
            if (term.LocalName == nodeName)
            {
                return term.Attributes["text"].InnerText;
            }
        }

        Debug.LogError("Nao encontrou o termo" + nodeName);

        return "NULO";

        //return currentLanguageDocument["LanguageData"][nodeName].Attributes["text"].InnerText;
    }
}
