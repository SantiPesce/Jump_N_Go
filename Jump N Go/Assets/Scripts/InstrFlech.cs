using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrFlech : MonoBehaviour
{
    public static int check = 0;

    public static SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check >= 3)
        {
            spr.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }

        if (check == 0)
        {
            spr.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
        }
    }
}
