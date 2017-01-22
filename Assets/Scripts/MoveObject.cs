using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public Vector3 speed = new Vector3(0.0f,-0.02f,0.0f);
    public float timeToDisable = 1;

    void Update()
    {
        if (PauseManager.instance.paused) return;

        if (!((gameObject.tag == "Player") && (GameManager.instance.worldSpeed.y == 0.0f)))
            transform.position += (speed + GameManager.instance.worldSpeed);
        else if (gameObject.tag == "Player")
            transform.position += speed;
    }

    void OnBecameInvisible()
    {
        if (PauseManager.instance.paused) return;

        if(transform.position.y < -4.0f)
            StartCoroutine("DisableAfter");
    }

    IEnumerator DisableAfter ()
    {
        yield return new WaitForSeconds(timeToDisable);

        if ((gameObject.tag == "Player"))
        {
            if (transform.position.y < 0.0f)
                GetComponent<PlayerController>().Die();
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("inactive " + gameObject.transform.name);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
