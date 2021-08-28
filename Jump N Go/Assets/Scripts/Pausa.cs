using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public AudioClip bipButtons;
    AudioSource fuenteAudio;
    //public static AudioManager audioManager;

    public bool activeMenu = false;
    public bool activeQuit = false;
    public bool activePause = false;

    public GameObject fireCreator;
    public GameObject player;

	bool active = false;
	Canvas canvas;

	// Use this for initialization
	void Start ()
    {
        fuenteAudio = GetComponent<AudioSource>();
        canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (activePause == true){
			active = true;
			canvas.enabled = active;
            player.SendMessage("PPause");
            fireCreator.SendMessage("PPause");
        } else{
            active = false;
            canvas.enabled = active;
        }

        if (canvas.enabled == true) {
            if (activeQuit == true)
            {
                print("Cerrando Juego...");
                Application.Quit();
            }
            else if (activeMenu == true)
            {
                if (OutroLvl.tutorial == true)
                {
                    OutroLvl.tutorial = false;
                }
                PlayerController.power = false;
                UpFire.oN = false;
                FireCreator.block = false;
                InstrFlech.check = 0;
                SceneManager.LoadScene("Menu");
            }
        }
	}

    public void ActivePausee()
    {
        Sound();
        activePause = true;
        Time.timeScale = 0f;
    }

    public void DesactivePausee()
    {
        Sound();
        activePause = false;
        Time.timeScale = 1f;
    }

    public void ActiveMenuu()
    {
        Sound();
        activeMenu = true;
        Time.timeScale = 1f;
    }

    public void DesactiveMenuu()
    {
        Sound();
        activeMenu = false;
    }

    public void ActiveQuitt()
    {
        Sound();
        activeQuit = true;
    }

    public void DesactiveQuitt()
    {
        Sound();
        activeQuit = false;
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
