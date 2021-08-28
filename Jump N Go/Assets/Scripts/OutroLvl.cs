using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroLvl : MonoBehaviour
{
    public AudioClip finNivel;
    public AudioClip gameOver;
    AudioSource fuenteAudio;
    //public static AudioManager audioManager;

    public static bool l1_Ent2;
    public static bool l2_Ent3;
    public static bool l3_Ent4;
    public static bool l2_EntP;
    public static bool l3_EntU;
    public static bool l4_EntL;
    public static bool lP_EntLvls;
    public static bool lU_EntLvs;
    public static bool lL_EntLvs;

    [Range(0, 1)]
    public float transparent = 0;

    public static bool cont;
    public float content_time;
    public float limit_time;
    public float content_time2;
    public float limit_time2;

    public static bool cont1;
    public float content_time1;
    public float limit_time1;

    public static bool tutorial;

    private SpriteRenderer spr;

    // Use this for initialization
    void Start()
    {
        l1_Ent2 = false;
        l2_Ent3 = false;
        l3_Ent4 = false;
        l2_EntP = false;
        l3_EntU = false;
        l4_EntL = false;
        lP_EntLvls = false;
        lU_EntLvs = false;
        lL_EntLvs = false;

        fuenteAudio = GetComponent<AudioSource>();

        cont = false;
        cont1 = false;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cont == true)
        {
            Time.timeScale = 0;
            content_time2 += 1;
        }

        if(content_time2 >= limit_time2)
        {
            transparent += 0.02f;
            spr.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, transparent);
            content_time += 1;
        }

        if (content_time >= limit_time)
        {
            Time.timeScale = 1;

            if (l1_Ent2 == true)
            {
                SceneManager.LoadScene("Level2");
                l1_Ent2 = false;
            }
            else if (l2_Ent3 == true)
            {
                SceneManager.LoadScene("Level3");
                l2_Ent3 = false;
            }
            else if (l2_EntP == true)
            {
                SceneManager.LoadScene("LevelPatineta");
                l2_EntP = false;
            }
            else if (lU_EntLvs == true)
            {
                SceneManager.LoadScene("Levels");
                lU_EntLvs = false;
            }
            else if (l3_Ent4 == true)
            {
                SceneManager.LoadScene("Level4");
                l3_Ent4 = false;
            }
            else if (l3_EntU == true)
            {
                SceneManager.LoadScene("Level¿");
                l3_EntU = false;
            }
            else if (l4_EntL == true)
            {
                SceneManager.LoadScene("LevelLaberinto");
                l4_EntL = false;
            }
            else if (lP_EntLvls == true)
            {
                SceneManager.LoadScene("Levels");
                lP_EntLvls = false;
            }
            else if (lL_EntLvs == true)
            {
                SceneManager.LoadScene("Levels");
                lL_EntLvs = false;
            }
            else
            {
            SceneManager.LoadScene("Menu");
            }
        }

        if (cont1 == true)
        {
            Time.timeScale = 0;
            transparent += 0.04f;
            spr.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, transparent);
            content_time1 += 1;
        }

        if (content_time1 >= limit_time1)
        {
            Time.timeScale = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (tutorial == true)
            {
                tutorial = false;
                SceneManager.LoadScene("Menu");
            }
            else
            {
                SceneManager.LoadScene("Levels");
            }
        }

        if (content_time1 == 1)
        {
            if (BtnSounds.on == true)
            {
                fuenteAudio.clip = gameOver;
                fuenteAudio.Play();
            }
        }

        if (content_time2 == 1)
        {
            if (BtnSounds.on == true)
            {
                fuenteAudio.clip = finNivel;
                fuenteAudio.Play();
            }
        }
    }
}
