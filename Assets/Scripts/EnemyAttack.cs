using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    [SerializeField] float attackDistance = 1f;

    GameObject player;
    Enemy enemy;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    bool playerInRange;
    float timer;


    void Start()
    {
        enemy = GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();

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
            bool inAttackRange = Vector3.Distance(player.transform.position, transform.position) < attackDistance;
            //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
            bool timeToAttack = timer >= timeBetweenAttacks;

            if (inAttackRange && timeToAttack)
            {
                timer = 0f;
                //Debug.Log("Can attack!");
                if (playerHealth.currentHealth > 0 && !enemyHealth.isDead)
                {
                    playerHealth.TakeDamage(attackDamage);
                }
            }
        }
        /*
        if (playerHealth.currentHealth > 0 && !enemyHealth.isDead)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        */
    }
}
