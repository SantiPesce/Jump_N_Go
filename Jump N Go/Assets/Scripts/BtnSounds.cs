﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSounds : MonoBehaviour
{
    static public bool on;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("on", on);
    }
}
