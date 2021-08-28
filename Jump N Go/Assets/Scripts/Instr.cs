using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instr : MonoBehaviour
{

    public bool cont;
    public float content_time;
    public float limit_time;

    public bool cont2;
    public float content_time2;
    public float limit_time2;

    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        cont = true;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cont == true)
        {
            content_time += Time.deltaTime;
        }

        if (content_time >= limit_time)
        {
            content_time = 0;
            spr.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
            cont = false;
            cont2 = true;
        }

        if (cont2 == true)
        {
            content_time2 += Time.deltaTime;
        }

        if (content_time2 >= limit_time2)
        {
            content_time2 = 0;
            spr.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 0 / 255f);
            cont2 = false;
            cont = true;
        }
    }
}
