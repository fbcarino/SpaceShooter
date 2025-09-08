using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBossShield : MonoBehaviour
{
    public float hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Projectile")
        {
            Destroy(other.gameObject);
            hitPoints -= 1;
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
