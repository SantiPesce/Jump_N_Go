using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : Menu
{
    public AudioClip upFire;
    public AudioClip jumP;
    public AudioClip enemyHit;

    AudioSource fuenteAudio;
    //public new static AudioManager audioManager;

    public bool coin;

    public bool ntr = false;
    public bool ntr1 = false;
    public bool ntr2 = false;
    public bool ntr3 = false;

    public int contJump;
    public bool jumpp;

    public GameObject instr;
    public GameObject instr1;
    public GameObject instr2;
    public GameObject instr3;
    public GameObject instr4;

    public GameObject EnemyRInd;
    public GameObject EnemyBInd;

    public bool aRight;

    public static bool gameOver;

    public static bool activeBtn;
    public static bool activeJmp;
    public static bool activeEnemyR;
    public static bool activeBlock;
    public static bool activeFire;
    public static bool activeEnemyB;
    public static bool activeDanger;

    public static bool attack;
    public static bool activeRight = false;
    public static bool activeLeft = false;

    public GameObject colCrEnem;

    bool active;

    //public Text pointEnemBText;
    //public Text pointEnemText;
    public Text pointText;
    public Text healthText;

    public GameObject door;

    public static bool power;
    public static bool right;
    public static bool left;

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;
    public float health = 100f;
    public float damage = 1f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;

    //private GameObject healthbar;

    // Use this for initialization
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();

        contJump = 0;

        right = false;
        left = false;

        attack = false;

        gameOver = false;

        activeBtn = true;
        activeJmp = false;
        activeFire = false;
        activeEnemyB = false;
        activeDanger = false;

        active = true;
        pointText.text = (puntos).ToString();
        healthText.text = (healthPoints).ToString();
        //pointEnemText.text = (puntosEnemies).ToString();
        //pointEnemBText.text = (puntosEnemiesB).ToString();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        //healthbar = GameObject.Find("Healthbar");
    }

    // Update is called once per frame
    void Update()
    {
        if (coin == true)
        {
            IncreacePoints();
            ShowPoints(puntos);
            coin = false;
        }

        if (ntr == true)
        {
            InstrFlech.check ++;
            ntr = false;
        }
        if (ntr1 == true)
        {
            InstrFlech.check ++;
            ntr1 = false;
        }
        if (ntr2 == true)
        {
            InstrFlech.check ++;
            ntr2 = false;
        }
        if (ntr3 == true)
        {
            InstrFlech.check ++;
            ntr3 = false;
        }

        if (jumpp == true && contJump < 2)
        {
            jump = true;
            jumpp = false;

            if (BtnSounds.on == true)
            {
                fuenteAudio.clip = jumP;
                fuenteAudio.Play();
            }
        }

        if (grounded == true)
        {
            contJump = 0;
        }

        anim.SetBool("aright", aRight);

        anim.SetBool("attack", attack);

        anim.SetBool("power", power);

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
    }

    void FixedUpdate()
    {
        if(activeRight == true)
        {
            right = true;
            left = false;
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;

            if (grounded)
            {
                rb2d.velocity = fixedVelocity;
            }
            
            rb2d.AddForce(Vector2.right * speed);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else{
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;

            if (grounded)
            {
                rb2d.velocity = fixedVelocity;
            }

            rb2d.AddForce(Vector2.right * speed * 0);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        }

        if (activeLeft == true)
        {
            left = true;
            right = false;
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;

            if (grounded)
            {
                rb2d.velocity = fixedVelocity;
            }
            
            rb2d.AddForce(Vector2.right * -speed);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else{
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;

            if (grounded)
            {
                rb2d.velocity = fixedVelocity;
            }

            rb2d.AddForce(Vector2.right * speed * 0);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        }
        
        //SALTO
        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }

    public void EnemyJump()
    {
        jump = true;
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        if (BtnSounds.on == true)
        {
            fuenteAudio.clip = enemyHit;
            fuenteAudio.Play();
        }

        activeLeft = false;
        activeRight = false;

        power = false;

        //healthbar.SendMessage("TakeDamage", 15);
        DencreaceHealth();

        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
        
        Invoke("EnableMovement", 0.7f);

        Color color = new Color(206 / 255f, 45 / 255f, 45 / 255f, 255 / 255f);
        spr.color = color;

        /*if (health > 15)
        {
            health = health - (damage * 15f);
        }
        else if (health <= 15)
        {
            gameOver = true;
            puntos = 0;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            OutroLvl.cont1 = true;
        }*/

        if (healthPoints <= 0)
        {
            gameOver = true;
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            FireCreator.block = false;
            UpFire.oN = false;
            power = false;
            InstrFlech.check = 0;
            OutroLvl.cont1 = true;
        }
    }

    void EnableMovement()
    {
        spr.color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collider")
        {
            col.isTrigger = true;
        }
        else if (col.gameObject.tag == "Block")
        {
            if (BtnSounds.on == true)
            {
                fuenteAudio.clip = upFire;
                fuenteAudio.Play();
            }

            Destroy(instr4);
            FireCreator.block = true;
            UpFire.oN = true;
            activeDanger = true;

            Destroy(instr3);
        }
        else if (col.gameObject.tag == "PBox")
        {
            PBox.oN = true;
        }
        else if (col.gameObject.tag == "Patineta")
        {
            //AudioManager._patineta = true;
            Patineta.entr = true;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Door")
        {
            door.SendMessage("Active");
        }
        else if (col.gameObject.tag == "Respawn")
        {
            DesactiveLeftt();
            DesactiveRightt();
            gameOver = true;
            puntos = 0;
            healthPoints = 5;
            puntosEnemies = 0;
            puntosEnemiesB = 0;
            power = false;
            UpFire.oN = false;
            FireCreator.block = false;
            InstrFlech.check = 0;
            OutroLvl.cont1 = true;
        }
        else if (col.gameObject.tag == "CollEnd") //Level 1
        {
            DesactiveLeftt();
            DesactiveRightt();
            PlayerPrefs.SetInt("Lvl2", 1);
            OutroLvl.cont = true;
            OutroLvl.l1_Ent2 = true;
        }
        else if (col.gameObject.tag == "CollEnd2") //Level 2
        {
            DesactiveLeftt();
            DesactiveRightt();
            PlayerPrefs.SetInt("Lvl3", 1);
            OutroLvl.cont = true;
            OutroLvl.l2_Ent3 = true;
        }
        else if (col.gameObject.tag == "EntrLvlP")
        {
            if (Patineta.entr == true)
            {
                DesactiveLeftt();
                DesactiveRightt();
                PlayerPrefs.SetInt("LvlPatineta", 1);
                OutroLvl.cont = true;
                OutroLvl.l2_EntP = true;
            }
        }
        else if (col.gameObject.tag == "CollEnd¿") //Level ?
        {
            DesactiveLeftt();
            DesactiveRightt();
            OutroLvl.cont = true;
            OutroLvl.lU_EntLvs = true;

        }
        else if (col.gameObject.tag == "CollEnd3") //Level 3
        {
            DesactiveLeftt();
            DesactiveRightt();
            PlayerPrefs.SetInt("Lvl4", 1);
            OutroLvl.cont = true;
            OutroLvl.l3_Ent4 = true;

            /*power = false;
            UpFire.oN = false;
            FireCreator.block = false;
            OutroLvl.cont = true;*/
        }
        else if (col.gameObject.tag == "EntrLvl?")
        {
            DesactiveLeftt();
            DesactiveRightt();
            PlayerPrefs.SetInt("Lvl?", 1);
            OutroLvl.cont = true;
            OutroLvl.l3_EntU = true;
        }
        else if (col.gameObject.tag == "CollEnd4") //Level 4
        {
            DesactiveLeftt();
            DesactiveRightt();
            power = false;
            UpFire.oN = false;
            FireCreator.block = false;
            OutroLvl.cont = true;
        }
        else if (col.gameObject.tag == "EntrLvlL")
        {
            if (UpFire.oN == true)
            {
                DesactiveLeftt();
                DesactiveRightt();
                PlayerPrefs.SetInt("LvlLaberinto", 1);
                OutroLvl.cont = true;
                OutroLvl.l4_EntL = true;
            }
        }
        else if (col.gameObject.tag == "CollEndP") //Level Patineta
        {
            DesactiveLeftt();
            DesactiveRightt();
            OutroLvl.cont = true;
            OutroLvl.lP_EntLvls = true;
        }
        else if (col.gameObject.tag == "CollEndL") //Level Laberinto
        {
            DesactiveLeftt();
            DesactiveRightt();
            power = false;
            UpFire.oN = false;
            FireCreator.block = false;
            OutroLvl.cont = true;
            OutroLvl.lL_EntLvs = true;
        }
        else if (col.gameObject.tag == "CollEndT") //Tutorial
        {
            DesactiveLeftt();
            DesactiveRightt();
            power = false;
            UpFire.oN = false;
            FireCreator.block = false;
            InstrFlech.check = 0;
            OutroLvl.cont = true;
        }
        else if (col.gameObject.tag == "Coin")
        {
            coin = true;
        }
        else if (col.gameObject.tag == "ColCrEnem")
        {
            colCrEnem.SendMessage("StartGenerator");
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EndCrEnem")
        {
            colCrEnem.SendMessage("CancelGenerator");
        }else if (col.gameObject.tag == "Pinches")
        {
            DesactiveLeftt();
            DesactiveRightt();
            power = false;
            UpFire.oN = false;
            FireCreator.block = false;
            //healthbar.SendMessage("TakeDamage", 25);
            DencreaceHealth();
            DencreaceHealth();

            Color color = new Color(206 / 255f, 45 / 255f, 45 / 255f, 255 / 255f);
            spr.color = color;

            Invoke("EnableMovement", 0.4f);

            float side = Mathf.Sign(gameObject.transform.position.y + transform.position.y);
            rb2d.AddForce(Vector2.right * side * jumpPower, ForceMode2D.Impulse);

            /*if (health > 25)
            {
                health = health - (damage * 25f);
            }
            else if (health <= 25)
            {
                gameOver = true;
                puntos = 0;
                healthPoints = 3;
                puntosEnemies = 0;
                puntosEnemiesB = 0;
                OutroLvl.cont = true;
            }*/

            if (healthPoints <= 0)
            {
                gameOver = true;
                puntos = 0;
                healthPoints = 5;
                puntosEnemies = 0;
                puntosEnemiesB = 0;
                OutroLvl.cont1 = true;
            }
        }
        else if (col.gameObject.tag == "Degr")
        {
            Degr.cont = true;
            Destroy(col.gameObject);
        }
    }

    private void IncreacePoints()
    {
        ++puntos;
    }

    public void ShowPoints(int p)
    {
        pointText.text = (p).ToString();
    }

    public void DencreaceHealth()
    {
        healthText.text = (--healthPoints).ToString();
    }
    
    public void IncreacePointsEnemies()
    {
        //pointEnemText.text = (++puntosEnemies).ToString();
    }

    public void IncreacePointsEnemiesB()
    {
        //pointEnemBText.text = (++puntosEnemiesB).ToString();
    }

    void PPause()
    {
        active = !active;
    }

    public void ActiveJumpp()
    {
        jumpp = true;
        contJump += 1;
        Destroy(instr);
        ntr = true;
    }

    public void DesactiveJumpp()
    {
        jumpp = false;
    }

    public void ActiveRightt()
    {
        //AudioManager.countPat = true;
        activeRight = true;
        aRight = true;
        Destroy(instr1);
        ntr1 = true;
    }

    public void DesactiveRightt()
    {
        activeRight = false;
    }

    public void ActiveLeftt()
    {
        //AudioManager.countPat = true;
        activeLeft = true;
        aRight = false;
        Destroy(instr2);
        ntr2 = true;
    }

    public void DesactiveLeftt()
    {
        activeLeft = false;
    }

    public void ActiveAttackk()
    {
        attack = true;
        EnemyBController.attack = true;
        ntr3 = true;
    }

    public void DesactiveAttackk()
    {
        attack = false;
        EnemyBController.attack = false;
    }
}
