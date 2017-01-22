using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour {

    public static CameraShake instance;

    public float duration;
    public float strength;

    void OnEnable()
    {
        instance = this;
    }

    public void Shake()
    {
        transform.DOShakePosition(duration, strength);
    }
}
