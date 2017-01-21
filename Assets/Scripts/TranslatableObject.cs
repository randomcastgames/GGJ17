using UnityEngine;
using UnityEngine.UI;

public class TranslatableObject : MonoBehaviour
{
    public string term;
    public bool upper = false;

    public void Start()
    {
        GameManager.instance.translatableObjectsList.Add(this);
        ApplyTerm();
    }

    public void ApplyTerm()
    {
        if (upper)
        {
            GetComponent<Text>().text = GameManager.instance.FindTerm(term).ToUpper();
        }
        else
        {
            GetComponent<Text>().text = GameManager.instance.FindTerm(term);
        }
    }

    public void OnDisable()
    {
        GameManager.instance.translatableObjectsList.Remove(this);
    }
}
