using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPlayer : MonoBehaviour
{
    public float score;
    public float timer;
    public float health;
    public float speed;
    public float points;

    public bool onRightLevel = false;
    public GameObject boss;
    scriptBoss bossBrain;

    public int maxAmmo = 5;
    public int currentAmmo;
    public float reloadTime = 2f;
    bool isReloading = false;

    private float inputH;
    private float inputV;

    public Transform playerProjectileLauncher;
    public Transform playerProjectileLauncher2;
    public GameObject playerProjectile;

    public GameObject explosion;

    AudioSource playerSpeakers;
    public AudioClip shoot;
    public AudioClip reload;
    public AudioClip hit;
    public AudioClip destroy;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeakers = GetComponent<AudioSource>();       //allows playerSpeakers to get audio clips from audio source.
        InvokeRepeating("Countdown", 1, 1);                 //starts the function countdown.
        currentAmmo = maxAmmo;                              // the players current ammo will equal the max ammo.
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("sceneLevel1"))           //checks if scene is 'level1'
        {
            onRightLevel = true;                           //on the right level
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("sceneBossLevel"))    //checks if scene is 'boss level'
        {
            onRightLevel = false;                           //not on the right level.
            bossBrain = boss.GetComponent<scriptBoss>();              //allows to get components from boss
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.3f, 8.3f), Mathf.Clamp(transform.position.y, -4.4f, 4.4f), 0);         //creates boundaries for player
        inputH = Input.GetAxisRaw("Horizontal");                           //moves left 
        inputV = Input.GetAxisRaw("Vertical");                             //moves right
        transform.Translate(inputH * speed * Time.deltaTime, inputV * speed * Time.deltaTime, 0);       //directional movement around the screen.

        if (Input.GetKeyDown("space") && currentAmmo >0)
        {
            playerSpeakers.clip = shoot;       //have audio cip "shoot" on stand by
            playerSpeakers.Play();             //play audio clip "shooot'
            currentAmmo -= 1;                  //take one from ammo
            Instantiate(playerProjectile, playerProjectileLauncher.position, transform.rotation);
            Instantiate(playerProjectile, playerProjectileLauncher2.position, transform.rotation);
            points = Random.Range(1, 5);    //allows to randomize point value 
        }

        if (Input.GetKeyDown("c"))       //was the 'c' key pressed
        {
            StartCoroutine(Reload());    //start reload coroutine
            return;                       //return
        }

        if (isReloading)          //if reloading
        {
            return;               //return
        }
        if (Input.GetKeyDown("escape"))       //is the escape key pressed
        {
            SceneManager.LoadScene("sceneMainMenu");      //go to main menu
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")       //is the the sprite tagged as 'Enemy'
        {
            playerSpeakers.clip = hit;            //have hit audio clip on standby
            playerSpeakers.Play();                //play hit audio clip
            Destroy(other.gameObject);            //destroy enemy
            health -= 1;                          //take one health point from player health
        }
        else if (other.transform.tag == "Boss")   //is the sprite tagged as 'Boss'
        {
            playerSpeakers.clip = hit;            //have hit audio clip on standby
            playerSpeakers.Play();                //play hit audio clip
            health -= 1;                          //take one health point from player health
        }
        if (health <= 0)                //is health less than or equal to 0
        {
            StartCoroutine(Defeat());    //start coroutine 'Defeat'
        }

    }
    IEnumerator Reload() 
    {
        isReloading = true;              //is relaoding will be true
        playerSpeakers.clip = reload;    //have reload audio clip on standby
        playerSpeakers.Play();           //play reload clip

        Debug.Log("Reloading...");       //type 'reloading...' in the console

        yield return new WaitForSeconds(reloadTime);      //wait for the amount of time in the reloadTime
          
        currentAmmo = maxAmmo;     //currentAmmo will go back to maxAmmo
        isReloading = false;       //is reloading is back to false
    }
    void Countdown()
    {
        timer -= 1;      //take a second out of timer
        if (timer <= 0)  //is timer less than or equal to 0
        {
            CancelInvoke("Countdown");   //stop countdown timer
            if (onRightLevel == true)    //is it on level 1
            {
                SceneManager.LoadScene("sceneBossLevel");  //go to boss level
            }
            else if (onRightLevel)         //is it on boss level
            {
                if (bossBrain.hitPoints <=0)     //is the boss health equal to or less than 0
                {
                    SceneManager.LoadScene("sceneWin");   //go to scene win
                }
                else if (bossBrain.hitPoints >= 0)    //is the boss health more than or equal to 0
                {
                    SceneManager.LoadScene("sceneLose");   //go to scene lose
                }

            }

        }
    }
    IEnumerator Defeat()     //defeat sequnce
    {
        playerSpeakers.clip = destroy;   //have audio clip destroy on standby
        playerSpeakers.Play();           //play audio clip destroy
        GameObject bossSpaceShip = Instantiate(explosion, transform.position, Quaternion.identity);   //play particle system on player position 
        yield return new WaitForSeconds(.5f);       //wait for .5 seconds
        Destroy(gameObject);             //destroy player space ship
        SceneManager.LoadScene("sceneLose");  //go to scene lose
    }

}
