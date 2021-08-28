using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patineta : MonoBehaviour {

    public static bool oN;
    public static bool entr;

    private Animator anim;

    // Use this for initialization
    void Start () {
        entr = false;
        oN = false;

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("on", oN);
	}
}
