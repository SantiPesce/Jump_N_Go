using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class txtOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerController.gameOver == true && OutroLvl.cont == true)
        {
            transform.localScale = new Vector3(0.009269999f, 0.009269999f, 0.009269999f);
        }

        if (PlayerController.gameOver == true && OutroLvl.cont1 == true)
        {
            transform.localScale = new Vector3(0.009269999f, 0.009269999f, 0.009269999f);
        }
    }
}
