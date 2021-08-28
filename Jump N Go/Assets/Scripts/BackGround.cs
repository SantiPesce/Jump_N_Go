using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour {

	public float parallaxSpeed = 0.02f;
	public RawImage background;
	public GameObject player;

	public float scaleTime = 6f;
	public float scaleInc = .25f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (PlayerController.activeRight == true)
        {
            Parallax();
        }
        else if (PlayerController.activeLeft == true)
        {
            NParallax();
        }
	}

	void Parallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
	}

	void NParallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + -finalSpeed, 0f, 1f, 1f);
	}
}
