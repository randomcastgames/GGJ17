using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformPool : ObjectPool {

    public GameObject[] pool;

    private void OnEnable()
    {
        objectCount = pool.Length;
        objectsList = new GameObject[objectCount];

        for (int i = 0; i < objectCount; ++i)
        {
            objectsList[i] = (GameObject)Instantiate(pool[i], transform);
            objectsList[i].SetActive(false);
        }
    }
	
}
