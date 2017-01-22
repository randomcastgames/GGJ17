﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformManager : MonoBehaviour {

    public int numActivePlatforms;
    public float spaceBetweenGroups;
    GameObject[] platforms;
    Vector3 top_most;
    ObjectPool pool;

	// Use this for initialization
	void Start () {

        if (numActivePlatforms <= 1)
        {
            Debug.LogError("numActivePlatforms must be higher then 1");
            return;
        }

        pool = PoolManager.instance.FindPool("PlataformPool");

        if (pool == null)
            return;

        platforms = new GameObject[numActivePlatforms];
        platforms[0] = pool.GetRandomActiveObject();
        platforms[0].transform.position = new Vector3(0, spaceBetweenGroups);

        for (int i = 1; i  < numActivePlatforms; ++i)
        {
            platforms[i] = pool.GetRandomActiveObject();
            platforms[i].transform.position = new Vector3(0, platforms[i - 1].transform.position.y + spaceBetweenGroups);

            top_most = platforms[i].transform.position;
            Debug.Log(platforms[i].transform.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        for (; i < numActivePlatforms; i++)
        {
            if(platforms[i].activeSelf == false)
            {
                Debug.Log(platforms[i].transform.name + " Inactive");
                platforms[i] = pool.GetRandomActiveObject();
                if (platforms[i] == null) return;
                platforms[i].transform.position = new Vector3(0, spaceBetweenGroups);
            }
        }

	}
}
