using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptBossUI : MonoBehaviour
{
    public Text health;
    public Text ammo;
    public Text timer;
    public Text bossHealth;

    public GameObject player;
    scriptPlayer playerBrain;

    public GameObject boss;
    scriptBoss bossBrain;


    // Start is called before the first frame update
    void Start()
    {
        playerBrain = player.GetComponent<scriptPlayer>();
        bossBrain = boss.GetComponent<scriptBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + playerBrain.health;
        ammo.text = "Ammunition: " + playerBrain.currentAmmo;
        if (playerBrain.currentAmmo <= 0)
        {
            ammo.text = "Reload";
        }
        timer.text = "Time: " + playerBrain.timer;
        bossHealth.text = "Boss Health: " + bossBrain.hitPoints;
    }
}
