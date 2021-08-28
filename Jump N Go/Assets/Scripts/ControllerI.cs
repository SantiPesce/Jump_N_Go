using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerI : MonoBehaviour {

    public static bool cont;
    public float content_time;
    public float limit_time;

    // Use this for initialization
    void Start () {
        cont = false;
    }
	
	// Update is called once per frame
	void Update () {
        content_time += Time.deltaTime;

        if (content_time >= limit_time)
        {
            content_time += 0f;
            SceneManager.LoadScene("Menu");
        }
    }
}
