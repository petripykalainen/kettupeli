using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup : MonoBehaviour
{

    private Transform player;
    private Inventory inventory;
    public GameObject healthEffect;
    private ParticleSystem health;
    private GameObject test;
    private int whichSlot;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = player.GetComponentInChildren<ParticleSystem>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //healthEffect.transform.parent = player.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            whichSlot = 0;
            Use(whichSlot);
        }
        if (Input.GetKeyDown("2"))
        {
            whichSlot = 1;
            Use(whichSlot);
        }
        if (Input.GetKeyDown("3"))
        {
            whichSlot = 2;
            Use(whichSlot);
        }
        if (Input.GetKeyDown("4"))
        {
            whichSlot = 3;
            Use(whichSlot);
        }
        if (Input.GetKeyDown("5"))
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
            test = inventory.slots[w].transform.GetChild(0).gameObject;
            health.Play();
            //Destroy(gameObject);
            Destroy(test);
        }
    }
}