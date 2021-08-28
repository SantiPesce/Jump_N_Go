using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorOpen : MonoBehaviour {

	public GameObject p;
	public GameObject c;

	public float content_time;
	public float limit_time;

	private Animator anim;

	public bool oN;
	public bool dO;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		oN = false;
		dO = false;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("on", oN);
		anim.SetBool("Do", dO);
		if(oN == true){
			if(content_time >= limit_time){
				oN = false;
				dO = true;
				Destroy (c);
            }
			content_time += Time.deltaTime;
		}
	}

	void Active(){
		oN = true;
	}
}
