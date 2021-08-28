using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool men;

    public AudioClip musicM;
    public AudioClip musicG;
    public AudioClip bipButtons;

    AudioSource fuenteAudio;

    //public static AudioManager audioManager;

    public static int puntos = 0;
    public static int healthPoints = 5;
    public static int puntosEnemies = 0;
    public static int puntosEnemiesB = 0;

    // Use this for initialization
    void Start()
    {
        men = true;

        fuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("EntrConf") == false)
        {
            PlayerPrefs.SetFloat("audioSounds", 1);
            BtnSounds.on = true;
            PlayerPrefs.SetFloat("audioMusic", 1);
            BtnMusic.on = true;
        }

        if (PlayerPrefs.HasKey("audioSounds"))
        {
            BtnSounds.on = true;
        }
        else
        {
            BtnSounds.on = false;
        }

        if (PlayerPrefs.HasKey("audioMusic"))
        {
            BtnMusic.on = true;
        }
        else
        {
            BtnMusic.on = false;
        }
    }

    public void ActiveLevels()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }
        SceneManager.LoadScene("Levels");
    }

    public void ActiveConfigurations()
    {
        PlayerPrefs.SetInt("EntrConf", 1);
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }
        SceneManager.LoadScene("Configurations");
    }
    public void ActiveCredits()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }
    }

    public void ActiveTutorial()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }

        OutroLvl.tutorial = true;
        puntos = 0;
        healthPoints = 5;
        puntosEnemies = 0;
        puntosEnemiesB = 0;
        FireCreator.block = false;
        UpFire.oN = false;
        SceneManager.LoadScene("Tutorial");
    }

    public void ActiveLvl1()
    {
        puntos = 0;
        healthPoints = 5;
        puntosEnemies = 0;
        puntosEnemiesB = 0;
        SceneManager.LoadScene("Level1");
    }

    public void ActiveLvll2()
    {
        puntos = 0;
        healthPoints = 5;
        puntosEnemies = 0;
        puntosEnemiesB = 0;
        SceneManager.LoadScene("Level2");
    }

    public void ActiveLvll3()
    {
        puntos = 0;
        healthPoints = 5;
        puntosEnemies = 0;
        puntosEnemiesB = 0;
        SceneManager.LoadScene("Level3");
    }

    public void ActiveLvllU()
    {
        puntos = 0;
        healthPoints = 5;
        puntosEnemies = 0;
        puntosEnemiesB = 0;
        SceneManager.LoadScene("Level¿");
    }

    public void ActiveLvllPatineta()
    {
        puntos = 0;
        healthPoints = 5;
        puntosEnemies = 0;
        puntosEnemiesB = 0;
        SceneManager.LoadScene("LevelPatineta");
    }

    public void ActiveMusic()
    {
        if (PlayerPrefs.HasKey("audioMusic"))
        {
            PlayerPrefs.DeleteKey("audioMusic");
            if (BtnSounds.on == true)
            {
                fuenteAudio.clip = bipButtons;
                fuenteAudio.Play();
            }
        }
        else
        {
            PlayerPrefs.SetFloat("audioMusic", 1);
            if (BtnSounds.on == true)
            {
                fuenteAudio.clip = bipButtons;
                fuenteAudio.Play();
            }
        }
    }

    public void ActiveSounds()
    {
        if (PlayerPrefs.HasKey("audioSounds"))
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
            PlayerPrefs.DeleteKey("audioSounds");
        }
        else
        {
            PlayerPrefs.SetFloat("audioSounds", 1);
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }
    }

    public void Back()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }
        SceneManager.LoadScene("Menu");
    }
}
