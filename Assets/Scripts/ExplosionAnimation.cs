using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : SpriteAnimation
{
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartAnimation();
    }

    public override IEnumerator Animation()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            mySpriteRenderer.sprite = spriteList[index];
            index++;
            if (index >= spriteList.Length)
            {
                index = 0;
                Destroy(gameObject);
            }
        }

    }
}
