﻿using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public float timeBetweenAttacks = 0.5f;
    [SerializeField] public int attackDamage = 10;
    [SerializeField] public float attackRange = 3f;
    [SerializeField] public float timer;

    GameObject player;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        Attack();
    }


    void Attack()
    {
        if (player)
        {
            bool playerInRange = Vector3.Distance(transform.position, player.transform.position) < attackRange;
            bool timeToAttack = timer >= timeBetweenAttacks;

            if (playerInRange && timeToAttack)
            {
                timer = 0f;
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }
}
