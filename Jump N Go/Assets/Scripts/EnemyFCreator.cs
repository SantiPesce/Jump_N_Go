using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFCreator : MonoBehaviour
{

    public float generatorTimer = 1.75f;

    public GameObject enemy;

    // Use this for initialization
    void Start () {
        InvokeRepeating("CreateEnemy", 0f, generatorTimer);

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
