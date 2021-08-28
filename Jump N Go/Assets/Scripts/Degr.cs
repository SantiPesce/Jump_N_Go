using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degr : MonoBehaviour
{

    public static bool cont;
    public float content_time;
    public float limit_time;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        cont = false;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        if (cont == true)
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
            content_time += Time.deltaTime;
        }

        if (content_time >= limit_time)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            content_time = 0f;
            cont = false;
        }
    }
}
