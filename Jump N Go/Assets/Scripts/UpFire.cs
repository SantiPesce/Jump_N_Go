using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpFire : MonoBehaviour {

	public float content_time;
	public float limit_time;

	public static bool oN;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("ooN", oN);
		if (oN == true){
            OnFire.cont = true;
			PlayerController.power = true;
			content_time += Time.deltaTime;
			if(content_time >= limit_time){
				Destroy (gameObject);
			}
		}
	}
}
