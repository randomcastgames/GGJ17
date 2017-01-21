using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
    SpriteRenderer mySpriteRenderer;

    void OnEnable()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
