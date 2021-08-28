using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLvl : MonoBehaviour {

    public GameObject text;

    [Range(0,1)]
    public float transparent = 1;

    public bool cont;
    public float content_time;
    public float limit_time;

    public bool cont2;
    public float content_time2;
    public float limit_time2;

    private SpriteRenderer spr;

    // Use this for initialization
    void Start () {
        cont = true;
        Time.timeScale = 0;
        spr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (cont == true)
        {
            content_time += 1;
        }

        if (content_time >= limit_time)
        {
            transparent -= 0.05f;
            spr.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, transparent);
            cont = false;
            cont2 = true;
        }

        if (cont2 == true)
        {
            content_time2 += 1;
        }

        if (content_time2 >= limit_time2)
        {
            Time.timeScale = 1;
            cont2 = false;
            Destroy(gameObject);
            Destroy(text);
        }
    }
}
