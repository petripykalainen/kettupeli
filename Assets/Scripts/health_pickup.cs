﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup : MonoBehaviour {

    private Transform player;
    public GameObject healthEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        Instantiate(healthEffect, player.transform.position, Quaternion.Euler(-90, 0, 0));  // Quaternion.identity
        Destroy(gameObject);
    }
}
