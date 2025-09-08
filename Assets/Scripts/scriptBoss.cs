using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptBoss : MonoBehaviour
{
    public float bossSpeed;
    public float xMax;
    public float xMin;

    public bool goRight;

    public float hitPoints;
    public float fireRate;
    public float timer;

    

    public Transform bossProjectileLauncher;
    public Transform bossProjectileLauncher2;
    public GameObject bossProjectile;

    AudioSource playerSpeakers;
    public AudioClip shoot;
    public AudioClip hit;
    public AudioClip destroy;

    public GameObject explosion;

     void Start()
    {
        playerSpeakers = GetComponent<AudioSource>();
        goRight = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!goRight)                
        {
            bossSpeed = -Mathf.Abs(bossSpeed);
        }
        if (goRight)
        {
            bossSpeed = Mathf.Abs(bossSpeed);
        }

        transform.Translate(bossSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x >= xMax)
        {
            goRight = false;
        }
        if (transform.position.x <= xMin)
        {
            goRight = true;
        }

        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            Instantiate(bossProjectile, bossProjectileLauncher.position, transform.rotation);
            Instantiate(bossProjectile, bossProjectileLauncher2.position, transform.rotation);
            playerSpeakers.clip = shoot;
            playerSpeakers.Play();
            timer = 0;
        }
        if (hitPoints <= 20)
        {
            fireRate = 1f;
        }
        if (hitPoints <= 5)
        {
            fireRate = 0.5f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Projectile")
        {
            Destroy(other.gameObject);
            hitPoints -= 1;
            playerSpeakers.clip = hit;
            playerSpeakers.Play();
            if (hitPoints <= 0)
            {
                StartCoroutine(Defeat());
                SceneManager.LoadScene("sceneWin");
            }
        }
    }
    IEnumerator Defeat()
    {
        playerSpeakers.clip = destroy;
        playerSpeakers.Play();
        GameObject bossSpaceShip = Instantiate(explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        SceneManager.LoadScene("sceneWin");
    }
}