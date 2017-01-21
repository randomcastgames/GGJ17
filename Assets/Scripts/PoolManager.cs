using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    public static PoolManager instance;

    void OnEnable()
    {
        instance = this;
    }

    public ObjectPool FindPool(string name)
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i).name == name)
            {
                return transform.GetChild(i).GetComponent<ObjectPool>();
            }
        }

        Debug.LogError("Não encontrou a pool");
        return null;
    }
}
