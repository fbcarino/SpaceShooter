using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptUISystem : MonoBehaviour
{
    public Text score;
    public Text health;
    public Text ammo;
    public Text timer;

    private scriptUISystem UISystem;

    public GameObject player;
    scriptPlayer playerBrain;

    // Start is called before the first frame update
    void Start()
    {
        playerBrain = player.GetComponent<scriptPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + playerBrain.score;
        health.text = "Health: " + playerBrain.health;
        ammo.text = "Ammunition: " + playerBrain.currentAmmo;
        if (playerBrain.currentAmmo <= 0)
        {
            ammo.text = "Reload";
        }
        timer.text = "Time: " + playerBrain.timer;
    }
}