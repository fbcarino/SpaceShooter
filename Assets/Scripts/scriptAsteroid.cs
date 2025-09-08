using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAsteroid : MonoBehaviour
{
    public float speedY;
    public float speedX;

    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) < 20)
        {
            speedX = Random.Range(-0.5f, 0.5f);
        }
        else
        {
            speedX = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedX * Time.deltaTime, -speedY * Time.deltaTime, 0);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Projectile")
        {
            GameObject asteroid = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}