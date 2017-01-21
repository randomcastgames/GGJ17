using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public GameObject objectPrefab;
    public int objectCount;

    GameObject[] objectsList;

    void OnEnable()
    {
        objectsList = new GameObject[objectCount];

        for (int i = 0; i < objectCount; ++i)
        {
            objectsList[i] = (GameObject)Instantiate(objectPrefab, transform);
            objectPrefab.SetActive(false);
        }
    }

    public GameObject ActivateGameObject()
    {
        for (int i = 0; i < objectCount; ++i)
        {
            if (objectsList[i].activeSelf == false)
            {
                objectsList[i].SetActive(true);
                return objectsList[i];
            }
        }
        return null;
    }
}
