using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject enemy;
	GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    bool enemyInRange;
    float timer;


    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && enemyInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
    }


    void Attack()
    {
        timer = 0f;

        if (enemyHealth.currentHealth > 0 && !playerHealth.isDead)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
