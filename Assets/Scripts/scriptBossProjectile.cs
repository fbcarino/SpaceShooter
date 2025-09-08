using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBossProjectile : MonoBehaviour
{
    public float speedX;
    public float speedY;

    // Start is called before the first frame update
    void Start()
    {
        speedX = 0;
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
}
