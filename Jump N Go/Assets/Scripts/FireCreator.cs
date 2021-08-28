using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCreator : MonoBehaviour
{
    public AudioClip shoot;

    AudioSource fuenteAudio;
    //public static AudioManager audioManager;

    public bool activeFire = false;

    bool active;

    public static bool bonus;

	public GameObject firePrefab;
	public static bool exist;
	public static bool existF;
	public static bool block;

	// Use this for initialization
	void Start ()
    {
        fuenteAudio = GetComponent<AudioSource>();

        active = true;
        exist = false;
		existF = false;
		bonus = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (activeFire == true && block == true)
        {
            if (existF == false)
            {
                CreateFire();
                existF = true;
            }
        }
    }

	void CreateFire()
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = shoot;
            fuenteAudio.Play();
        }
        Instantiate (firePrefab, transform.position, Quaternion.identity);
	}

    void PPause()
    {
        active = !active;
    }

    public void ActiveFiree()
    {
        activeFire = true;
    }

    public void DesactiveFiree()
    {
        activeFire = false;
    }
}
