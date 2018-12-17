using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup : MonoBehaviour
{

    private GameObject player;
    private Inventory inventory;
    private PlayerHealth PlayerHealth;
    public GameObject healthEffect;
    public GameObject bombSpawn;
    private ParticleSystem health;
    private GameObject test;
    private int whichSlot;

    private int distance = 2;
    private AudioPlayer audio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.transform.GetChild(1).GetComponent<ParticleSystem>();
        inventory = player.GetComponent<Inventory>();
        PlayerHealth = player.GetComponent<PlayerHealth>();

        audio = GameObject.Find("audioManager").GetComponent<AudioPlayer>();
        //healthEffect.transform.parent = player.transform;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("1"))
        {
            whichSlot = 0;
            Use(whichSlot);
        }
        else if (Input.GetKeyDown("2"))
        {
            whichSlot = 1;
            Use(whichSlot);
        }
        else if (Input.GetKeyDown("3"))
        {
            whichSlot = 2;
            Use(whichSlot);
        }
        else if (Input.GetKeyDown("4"))
        {
            whichSlot = 3;
            Use(whichSlot);
        }
        else if (Input.GetKeyDown("5"))
        {
            whichSlot = 4;
            Use(whichSlot);
        }
    }

    public void Use(int w)
    {
        //Instantiate(healthEffect, player.transform.position, Quaternion.Euler(-90, 0, 0));  // Quaternion.identity
        if (inventory.slots[w].transform.childCount > 0)    // checks if the inventory slot has any children
        {
            Debug.Log(gameObject.tag);
            test = inventory.slots[w].transform.GetChild(0).gameObject;

            if ((test.tag == "Potion_image") && (PlayerHealth.currentHealth < 100))
            {
                health.Play();
                if(PlayerHealth.currentHealth >= 80)
                {
                    PlayerHealth.currentHealth = PlayerHealth.maxHealth;
                    PlayerHealth.healthSlider.value = PlayerHealth.maxHealth;
                }
                else
                {
                    //PlayerHealth.currentHealth += 20;
                    //PlayerHealth.healthSlider.value += 20;
                    PlayerHealth.TakeDamage(-20);
                }
                Destroy(test);
            }
            else if ((test.tag == "Bacon_image") && (PlayerHealth.currentHealth < 100))
            {
                if (PlayerHealth.currentHealth >= 95)
                {
                    PlayerHealth.currentHealth = PlayerHealth.maxHealth;
                    PlayerHealth.healthSlider.value = PlayerHealth.maxHealth;
                }
                else
                {
                    //PlayerHealth.currentHealth += 5;
                    //PlayerHealth.healthSlider.value += 5;
                    PlayerHealth.TakeDamage(-5);
                }
                audio.playBaconAudio();
                Destroy(test);
            }
            else if (test.tag == "Bomb_image")
            {
                Instantiate(bombSpawn, player.transform.position - player.transform.forward * distance, Quaternion.identity); // spawnaa pelaajan taakse
                // ignite audio tapahtuu vasta BombExplosion scriptissä
                Destroy(test);
            }
            //currentHealth += amount;
            //Destroy(gameObject);
        }
    }
}