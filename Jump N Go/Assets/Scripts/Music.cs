using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musicM;
    public AudioClip musicG;
    AudioSource fuenteAudio;
    //public static AudioManager audioManager;

    public static Music musicD;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (musicD == null)
        {
            musicD = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (musicD != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (BtnMusic.on == true)
        {
            if (Menu.menus == true)
            {
                fuenteAudio.clip = musicM;
                fuenteAudio.Play();
            }
            else if (Menu.menus == false)
            {
                fuenteAudio.clip = musicG;
                fuenteAudio.Play();
            }
        }*/
    }
}
