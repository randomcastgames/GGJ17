using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float speed;

    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + speed * Time.deltaTime, -10.0f);
    }
}
