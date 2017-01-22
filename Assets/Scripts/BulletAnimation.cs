using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : SpriteAnimation {

	// Use this for initialization
	void Start () {
        mySpriteRenderer = GameObject.FindWithTag("bullet").GetComponent<SpriteRenderer>();
        StartAnimation();
    }
}
