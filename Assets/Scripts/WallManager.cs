using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {
    public float initalYPos;
    public float centerPos;
    public float wallSpace;

    public float height;

    GameObject lastWall;

    // Use this for initialization
    void OnEnable () {
        for (int i = 0; ; ++i)
        {
            GameObject wall = PoolManager.instance.FindPool("WallPool").ActivateGameObject();
            if (wall == null) break;

            //float height = wall.GetComponent<SpriteRenderer>().sprite.rect.height/100.0f;

            wall.transform.localPosition = new Vector3(centerPos, initalYPos + height * i, 0.0f);

            //wall = PoolManager.instance.FindPool("WallPool").ActivateGameObject();
            //wall.transform.localPosition = new Vector3(centerPos - wallSpace, initalYPos + height * i, 0.0f);

            lastWall = wall;
        }
    }
	
	// Update is called once per frame
	void Update () {
        GameObject wall;

        if (wall = PoolManager.instance.FindPool("WallPool").ActivateGameObject())
        {
            //float height = wall.GetComponent<SpriteRenderer>().sprite.rect.height / 100.0f;

            //if (lastWall.transform.position.x > centerPos)
                wall.transform.localPosition = new Vector3(centerPos, lastWall.transform.position.y+height+GameManager.instance.worldSpeed.y, 0.0f);
            //else
                //wall.transform.localPosition = new Vector3(centerPos + wallSpace, lastWall.transform.position.y + height, 0.0f);

            lastWall = wall;
        }

    }
}
