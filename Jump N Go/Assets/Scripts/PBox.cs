using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBox : MonoBehaviour {

    public float content_time;
    public float limit_time;

    public static bool oN;

    // Use this for initialization
    void Start () {
        oN = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (oN == true)
        {
            content_time += Time.deltaTime;
        }

        if (content_time >= limit_time)
        {
            Patineta.oN = true;
            Destroy(gameObject);
        }
    }
}
