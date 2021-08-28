using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnFire : MonoBehaviour {

    public static bool cont;
    public float content_time;
    public float limit_time;

    public bool cont1;
    public float content_time1;
    public float limit_time1;

    public float content_time2;
    public float limit_time2;

    public static SpriteRenderer spr;

    // Use this for initialization
    void Start () {
        spr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerController.power == false)
        {
            cont = false;
            cont1 = false;
        }

        if(cont == true)
        {
            content_time2 += Time.deltaTime;
            content_time += Time.deltaTime;
        }
        if (content_time >= limit_time)
        {
            spr.color = new Color(222 / 255f, 43 / 255f, 43 / 255f, 255 / 255f);
            content_time = 0f;
            cont = false;
            cont1 = true;
            Texto.active = true;
        }
        if (cont1 == true)
        {
            content_time1 += Time.deltaTime;
        }
        if (content_time1 >= limit_time1)
        {
            spr.color = new Color(222 / 255f, 43 / 255f, 43 / 255f, 0 / 255f);
            content_time1 = 0f;
            cont = true;
            cont1 = false;
            Texto.active = false;
        }

        if (content_time2 >= limit_time2)
        {
            cont = false;
            spr.color = new Color(255 / 255f, 166 / 255f, 0 / 255f, 140 / 255f);
            Texto.active = true;
        }

        if (PlayerController.power == false)
        {
            spr.color = new Color(222 / 255f, 43 / 255f, 43 / 255f, 0 / 255f);
            Texto.active = false;
        }
    }
}
