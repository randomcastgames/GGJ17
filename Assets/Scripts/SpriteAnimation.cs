using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour {
    protected SpriteRenderer mySpriteRenderer;
    public Sprite[] spriteList;

    public float interval;

    protected int index;

    void OnEnable()
    {
        mySpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    public void StartAnimation()
    {
        index = 0;
        StartCoroutine("Animation");
    }

    public void StopAnimation()
    {
        StopCoroutine("Animation");
    }

    public virtual IEnumerator Animation()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            mySpriteRenderer.sprite = spriteList[index];
            index++;
            if (index >= spriteList.Length) index = 0;
        }

    }
}
