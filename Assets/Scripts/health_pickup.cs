using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup : MonoBehaviour {

    private Transform player;
    public GameObject healthEffect;
    private ParticleSystem health;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = player.GetComponentInChildren<ParticleSystem>();
        //healthEffect.transform.parent = player.transform;
    }

    public void Use()
    {
        //Instantiate(healthEffect, player.transform.position, Quaternion.Euler(-90, 0, 0));  // Quaternion.identity
        health.Play();
        Destroy(gameObject);
    }
}
