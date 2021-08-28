using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitM : MonoBehaviour {

    public AudioClip bipButtons;
    public AudioClip bipButtonsSalir;

    AudioSource fuenteAudio;

    //public static AudioManager audioManager;

    bool active = false;
    Canvas canvas;

    // Use this for initialization
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void Quit() {
        print("Cerrando Juego...");
        Application.Quit();
    }

    public void Active()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtonsSalir;
            fuenteAudio.Play();
        }
        active = true;
        canvas.enabled = active;
    }

    public void Desactive()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = bipButtons;
            fuenteAudio.Play();
        }
        active = false;
        canvas.enabled = active;
    }
}
