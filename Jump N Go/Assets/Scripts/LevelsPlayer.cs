using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsPlayer : Menu
{
    public new AudioClip bipButtons;

    AudioSource fuenteAudio;
    //public new static AudioManager audioManager;

    public float limit_cont1;
    public float limit_cont2;
    public float limit_cont3;
    public float limit_cont4;
    public float limit_contb1;
    public float limit_contb2;
    public float limit_contb3;

    public float cont1;
    public float cont2;
    public float cont3;
    public float cont4;
    public float contb1;
    public float contb2;
    public float contb3;

    public GameObject blocked;
    public GameObject blocked1;
    public GameObject blocked1_2;
    public GameObject blocked2;
    public GameObject blocked2_2;
    public GameObject blocked3;
    public GameObject blocked4;
    public GameObject blocked4_2;
    public GameObject blocked5;

    public bool on1 = false;
    public bool on2 = false;
    public bool on3 = false;
    public bool on4 = false;
    public bool onb1 = false;
    public bool onb2 = false;
    public bool onb3 = false;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("on1", on1);
        anim.SetBool("on2", on2);
        anim.SetBool("on3", on3);
        anim.SetBool("on4", on4);
        anim.SetBool("onb1", onb1);
        anim.SetBool("onb2", onb2);
        anim.SetBool("onb3", onb3);

        if (on1)
        {
            cont1 += Time.deltaTime;
        }

        if (on2)
        {
            cont2 += Time.deltaTime;
        }

        if (on3)
        {
            cont3 += Time.deltaTime;
        }

        if (on4)
        {
            cont4 += Time.deltaTime;
        }

        if (onb1)
        {
            contb1 += Time.deltaTime;
        }

        if (onb2)
        {
            contb2 += Time.deltaTime;
        }

        if (onb3)
        {
            contb3 += Time.deltaTime;
        }

        if (cont1 >= limit_cont1)
        {
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            SceneManager.LoadScene("Level1");
            cont1 = 0;
        }

        if (cont2 >= limit_cont2)
        {
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            SceneManager.LoadScene("Level2");
            cont2 = 0;
        }

        if (cont3 >= limit_cont3)
        {
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            SceneManager.LoadScene("Level3");
            cont3 = 0;
        }

        if (cont4 >= limit_cont4)
        {
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            SceneManager.LoadScene("Level4");
            cont4 = 0;
        }

        if (contb1 >= limit_contb1)
        {
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            SceneManager.LoadScene("LevelPatineta");
            contb1 = 0;
        }

        if (contb2 >= limit_contb2)
        {
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            SceneManager.LoadScene("Level¿");
            contb2 = 0;
        }

        if (contb3 >= limit_contb3)
        {
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            SceneManager.LoadScene("LevelLaberinto");
            contb3 = 0;
        }


        if (PlayerPrefs.HasKey("Lvl2"))
        {
            Destroy(blocked);
            Destroy(blocked1_2);
        }

        if (PlayerPrefs.HasKey("LvlPatineta"))
        {
            Destroy(blocked1);
        }

        if (PlayerPrefs.HasKey("Lvl?"))
        {
            Destroy(blocked2);
        }

        if (PlayerPrefs.HasKey("Lvl3"))
        {
            Destroy(blocked3);
            Destroy(blocked2_2);
        }

        if (PlayerPrefs.HasKey("LvlLaberinto"))
        {
            Destroy(blocked4);
        }

        if (PlayerPrefs.HasKey("Lvl4"))
        {
            Destroy(blocked5);
            Destroy(blocked4_2);
        }
    }

    public new void Back()
    {
        if (on1 == false && on2 == false && on3 == false && on4 == false && onb1 == false && onb2 == false && onb3 == false)
        {
            Sound();
            SceneManager.LoadScene("Menu");
        }
    }

    public void Active1()
    {
        Sound();
        on1 = true;
    }

    public void Active2()
    {
        Sound();
        on2 = true;
    }

    public void Active3()
    {
        Sound();
        on3 = true;
    }

    public void Active4()
    {
        Sound();
        on4 = true;
    }

    public void ActiveB1()
    {
        if (PlayerPrefs.HasKey("LvlPatineta"))
        {
            Sound();
            onb1 = true;
        }
        else if(PlayerPrefs.HasKey("Lvl2"))
        {
            Sound();
            on2 = true;
        }
    }

    public void ActiveB2()
    {
        if (PlayerPrefs.HasKey("Lvl?"))
        {
            Sound();
            onb2 = true;
        }
        else if (PlayerPrefs.HasKey("Lvl3"))
        {
            Sound();
            on3 = true;
        }
    }

    public void ActiveB3()
    {
        if (PlayerPrefs.HasKey("LvlLaberinto"))
        {
            Sound();
            onb3 = true;
        }
        else if (PlayerPrefs.HasKey("Lvl4"))
        {
            Sound();
            on4 = true;
        }
    }

    public void Sound()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }
    }
}
