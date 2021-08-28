using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int puntos;
    public static int puntosEnemies;
    public static int puntosEnemiesB;

    public Text pointEnemBText;
    public Text pointEnemText;
    public Text pointText;

    public static GameController gameController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (gameController == null)
        {
            gameController = this;
            DontDestroyOnLoad(gameObject);
        }else if (gameController != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
