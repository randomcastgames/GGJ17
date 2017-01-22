using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public GameObject objectPrefab;
    public int objectCount;

    protected GameObject[] objectsList;

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

    public GameObject GetRandomActiveObject()
    {

        int[] index_inactive_list;
        int j = 0;
        index_inactive_list = new int[objectCount];

        for (int i =0; i < objectCount; ++i)
        {
            if(objectsList[i].activeSelf == false)
            {
                index_inactive_list[j++] = i;
            }
        }

        if(j == 0)
            return null;

        int lottery = Random.Range(0, j);

        objectsList[index_inactive_list[lottery]].SetActive(true);
        return objectsList[index_inactive_list[lottery]];
    }
}
