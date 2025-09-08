using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scirptAsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public float spawnRate;
    public float timer;

    public GameObject player;
    scriptPlayer playerBrain;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        playerBrain = player.GetComponent<scriptPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-8f, 8f), 6, 0), transform.rotation);
            timer = 0;
        }

        if (playerBrain.timer <= 20)
        {
            spawnRate = 0.5f;
        }
        if (playerBrain.timer <= 10)
        {
            spawnRate = 0.25f;
        }
    }
}
