using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public AudioClip coiN;

    AudioSource fuenteAudio;

    public bool cont;
    public float content_time;
    public float limit_time;

    private Animator anim;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        cont = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("cont", cont);

        if (cont == true)
        {
            content_time += Time.deltaTime;
        }

        if (content_time >= limit_time)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (BtnSounds.on == true)
            {
            fuenteAudio.clip = coiN;
            fuenteAudio.Play();
            }

            cont = true;
        }
    }
}
