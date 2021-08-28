using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public float content_time;
    public float limit_time;
    private SpriteRenderer spr;

    public float content_time1;
    public float limit_time1;

    // Use this for initialization
    void Start () {
        spr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        content_time += Time.deltaTime;
        if (content_time >= limit_time)
        {
            Color color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
            spr.color = color;
            content_time1 += Time.deltaTime;
            if (content_time1 >= limit_time)
            {
                content_time = 0f;
                content_time1 = 0f;
            }
        } else
        {
            Color color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 93 / 255f);
            spr.color = color;
        }
    }
}
