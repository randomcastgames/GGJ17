using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    public static PauseManager instance;

    GameObject pauseObj;
    public bool paused = false;

    AudioSource audioSource;

	// Use this for initialization
	void OnEnable () {
        instance = this;

        audioSource = GetComponent<AudioSource>();

        pauseObj = GameObject.FindWithTag("pause");
        pauseObj.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseControl();
        }
    }

    public void pauseControl()
    {
        audioSource.Stop();
        audioSource.Play();

        if (Time.timeScale == 1)
        {
            paused = true;
            Time.timeScale = 0;
            pauseObj.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            paused = false;
            Time.timeScale = 1;
            pauseObj.SetActive(false);
        }
    }
}
