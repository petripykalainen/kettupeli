using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    bool playerInRange;
    float timer;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            RaycastHit hit;
            Vector3 direction = other.transform.position - transform.position;
            LayerMask mask = LayerMask.GetMask("Player");

            if (Physics.Raycast(transform.position, direction, out hit, 5f, mask))
            {
                playerInRange = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            RaycastHit hit;
            Vector3 direction = other.transform.position - transform.position;
            LayerMask mask = LayerMask.GetMask("Player");

            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, mask))
            {
                Debug.DrawRay(transform.position, direction, Color.yellow, 0.5f);
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0 && !enemyHealth.isDead)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
