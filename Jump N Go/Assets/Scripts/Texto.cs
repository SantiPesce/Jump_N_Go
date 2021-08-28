using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour {

    public static bool active;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerController.power == false)
        {
            active = false;
        }

        if (active == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (active == false)
        {
            transform.localScale = new Vector3(0f, 1f, 1f);
        }
    }
}
