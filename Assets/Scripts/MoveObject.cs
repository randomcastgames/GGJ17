using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public Vector3 speed;
    public float timeToDisable = 1;

    void Update()
    {
        transform.position += speed;
    }

    void OnBecameInvisible()
    {
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
