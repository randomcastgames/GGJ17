using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public Vector3 speed;

    void Update()
    {
        transform.position += speed;
    }

    void OnBecameInvisible()
    {
        if((gameObject.tag == "Player"))
        {
            if(transform.position.y < 0.0f)
                GetComponent<PlayerController>().Die();
        }
        else
        {
            if (gameObject.activeSelf == true)
                gameObject.SetActive(false);
        }
    }
}
