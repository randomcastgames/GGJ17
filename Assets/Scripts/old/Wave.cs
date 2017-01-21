
using System;
using UnityEngine;


public class Wave : MonoBehaviour {

    public enum DIRECTION{
        LEFT_2_RIGHT,
        RIGHT_2_LEFT
    };

    public LineRenderer line;
    public float speed;
    public int points_poll_size;
    public float initial_x;
    public DIRECTION dir;


    private Vector3[] wave_points;
    private int head_index;
    private int tail_index;
    
	// Use this for initialization
	void Start () {
        head_index = 0;
        tail_index = 0;

        wave_points = new Vector3[points_poll_size];
	}
	
	// Update is called once per frame
	void Update () {
        int i = head_index - 1;
        int j = 0;
        if (i < 0) i = points_poll_size - 1;

        while(i != tail_index)
        {
           
            if (dir == DIRECTION.LEFT_2_RIGHT)
                wave_points[i].x += speed;
            else
                wave_points[i].x -= speed;

            if (j == line.numPositions)
                line.numPositions++;

            if (j == points_poll_size)
                Debug.Log("j >= poll");

            line.SetPosition(j++, wave_points[i]);

            if (--i < 0)
                i = points_poll_size - 1;

        }
	}

    public void addPoint (float y)
    {
        wave_points[head_index].Set(initial_x,y,0);
        ++head_index;

        if (head_index >= points_poll_size)
            head_index = 0;

        if (head_index == tail_index)
        {
            ++tail_index;

            if (tail_index == points_poll_size)
                tail_index = 0;
        }
    }

    public Vector3 getPointCloser2X(float x)
    {
        float current_best = Math.Abs(x - wave_points[tail_index].x);
        int best_index = tail_index;

        for (int i = tail_index; i != head_index; ++i)
        {
            if (i >= points_poll_size)
                i = 0;

            if (Math.Abs(x - wave_points[i].x) < current_best){
                current_best = Math.Abs(x - wave_points[i].x);
                best_index = i;
            }

        }

        return wave_points[best_index];
    }
}
