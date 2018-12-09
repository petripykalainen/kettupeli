using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

	GameObject player;
    PlayerHealth playerHealth;

    bool enemyInRange;
    float timer;


    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
    /*
    void Attack()
    {
        timer = 0f;

        if (enemyHealth.currentHealth > 0 && !playerHealth.isDead)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }
    */
}
