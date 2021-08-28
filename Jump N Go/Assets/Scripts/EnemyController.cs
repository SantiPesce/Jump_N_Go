using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip enemyDie;
    AudioSource fuenteAudio;
    //public static AudioManager audioManager;

    public float content_time1;
    public float limit_time1;
    public bool enemdiefire;

    public float content_time;
    public float limit_time;
    public bool enemdie;
    private Animator anim;

    public GameObject player;

    public float maxSpeed = 1f;
    public float speed = 1f;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();

        enemdie = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("enemdie", enemdie);
        anim.SetBool("enemdiefire", enemdiefire);

        if (enemdie == true)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            content_time += Time.deltaTime;
        }

        if (content_time >= limit_time)
        {
            enemdie = false;
            content_time = 0f;
            rb2d.isKinematic = true;
            Destroy(gameObject);
        }

        if (enemdiefire == true)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            content_time1 += Time.deltaTime;
        }

        if (content_time1 >= limit_time1)
        {
            enemdiefire = false;
            FireController.expl = true;
            content_time1 = 0f;
            Destroy(gameObject);
            player.SendMessage("IncreacePointsEnemies");
        }
    }

    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 0.04f;
            UpFire.oN = false;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                if (BtnSounds.on == true)
                {
                    fuenteAudio.clip = enemyDie;
                    fuenteAudio.Play();
                }

                enemdie = true;
                player.SendMessage("EnemyJump");
                player.SendMessage("IncreacePointsEnemies");
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
                if (FireCreator.block == true)
                {
                    FireCreator.block = false;
                }
            }
        }
        else if (col.gameObject.tag == "Fire")
        {
            if (BtnSounds.on == true)
            {
                fuenteAudio.clip = enemyDie;
                fuenteAudio.Play();
            }

            FireController.expl = true;
            rb2d.isKinematic = true;
            enemdiefire = true;
        }
        else if (col.gameObject.tag == "Finish")
        {
            player.SendMessage("EnemyKnockBack", transform.position.x);
            if (FireCreator.block == true)
            {
                FireCreator.block = false;
            }
        }
    }
}
