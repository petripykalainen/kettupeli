using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public float timeBetweenAttacks = 0.5f;
    [SerializeField] public int attackDamage = 10;
    [SerializeField] public float attackRange = 4f;
    [SerializeField] public float timer;
    [SerializeField] List<AudioClip> hitSfx;

    AudioSource audioPlayer;

    GameObject player;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    private Animator anim;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();

    }

    public void Attack()
    {
        if (player)
        {
            bool playerInRange = Vector3.Distance(transform.position, player.transform.position) < attackRange;
            //bool timeToAttack = timer >= timeBetweenAttacks;
            bool playerIsAlive = playerHealth.currentHealth > 0;

            if (playerInRange && playerIsAlive)
            {
                anim.SetTrigger("Attack");
            }
        }
    }

    public void PlayAttackSFX()
    {
        int index = UnityEngine.Random.Range(0, hitSfx.Count - 1);
        //Debug.Log(hitSfx[index]);
        audioPlayer.PlayOneShot(hitSfx[index]);
    }
}

   
