using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpFire1 : MonoBehaviour {

    public float content_time;
    public float limit_time;

    public static bool ooN;

    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        ooN = false;
    }

    // Update is called once per frame
    void Update() {
        anim.SetBool("ooN", ooN);
        if (ooN == true) {
            PlayerController.power = true;
            content_time += Time.deltaTime;
            if (content_time >= limit_time) {
                Destroy(gameObject);
            }
        }
    }
}
