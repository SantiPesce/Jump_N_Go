using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    public AudioClip explocionFire;
    AudioSource fuenteAudio;
    //public static AudioManager audioManager;

    public bool exist;

    public float content_time;
    public float limit_time;
    
    public static bool expl;

    public GameObject fireDstry;

	public float maxSpeed = 1f;
	public float speed = 1f;

	private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        fuenteAudio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        expl = false;
        exist = true;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("expl",expl);

        if (expl == true)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            content_time += Time.deltaTime;
        }

        if (content_time >= limit_time)
        {
            expl = false;
            Destroy(gameObject);
            content_time = 0f;
            FireCreator.existF = false;
        }

        if (PlayerController.right == true && exist == true)
        {
            rb2d.AddForce(Vector2.right * speed);
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
            exist = false;
        }
        else if (PlayerController.left == true && exist == true)
        {
            rb2d.AddForce(Vector2.left * speed);
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
            exist = false;
        }
    }

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy") {
            FireCreator.existF = false;
            rb2d.isKinematic = true;
            expl = true;
            Sound();
        } else if (col.gameObject.tag == "FireDstrys")
        {
            Sound();
            expl = true;
            rb2d.isKinematic = true;
        }
        else if (col.gameObject.tag == "Ground")
        {
            Sound();
            expl = true;
            rb2d.isKinematic = true;
        }
        else if (col.gameObject.tag == "Castillo")
        {
            Sound();
            expl = true;
            rb2d.isKinematic = true;
        }
    }

    public void Sound()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = explocionFire;
            fuenteAudio.Play();
        }
    }
}
