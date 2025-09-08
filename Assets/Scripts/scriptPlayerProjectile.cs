using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlayerProjectile : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);     //moves projectile up.
        if (transform.position.y > 5)                          //Did projectile go beyond y=5?
        {
            Destroy(gameObject);                               //If so, destroy prjectile.
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")               //is the object tagged as 'Enemy'             
        {
            GameObject player = GameObject.Find("Space Ship");
            scriptPlayer playerBrain = player.GetComponent<scriptPlayer>();
            playerBrain.score += playerBrain.points;
            Destroy(gameObject);
        }
    }
}
