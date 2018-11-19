using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public List<GameObject> enemyList;
    public List<String> kusivittu;

    public GameObject enemy;
	GameObject player;
    PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;

    //bool enemyInRange;
    float timer;


    void Start()
    {
        enemyList = new List<GameObject>();
		player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log(other + " Entered Player.");
            //enemyInRange = true;
            enemy = other.gameObject;
            enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (!enemyList.Contains(other.gameObject))
            {
                enemyList.Add(other.gameObject);
            }
            //Debug.Log(enemyHealth + " : " + enemy);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //enemyInRange = false;
            enemy = null;
            enemyHealth = null;
            if (enemyList.Contains(other.gameObject))
            {
                enemyList.Remove(other.gameObject);
            }
            //Debug.Log(enemyHealth + " : " + enemy);
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && Input.GetKey(KeyCode.Alpha1))
        {
            Attack();
        }
    }


    void Attack()
    {
        timer = 0f;
        int lenghtOfEnemyList = enemyList.Count;

        if (enemyList.Count >= 0)
        {
            for (int i = 0; i < lenghtOfEnemyList; i++)
            {
                EnemyHealth enemyHealth = enemyList[i].GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(attackDamage);
                if (enemyHealth.isDead)
                {
                    enemyList.Remove(enemyList[i]);
                }
            }
        }
        else
        {
            Debug.Log("There is no enemy");
        }
    }
}
