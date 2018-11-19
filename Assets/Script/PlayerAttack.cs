using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    public GameObject enemy;
	GameObject player;
    PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;

    bool enemyInRange;
    float timer;


    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other + " Entered Player.");
            enemyInRange = true;
            enemy = other.gameObject;
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            Debug.Log(enemyHealth + " : " + enemy);
        }
    }
  
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = false;
            enemy = null;
            enemyHealth = null;
            Debug.Log(enemyHealth + " : " + enemy);
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
        if (enemyHealth)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
        else
        {
            Debug.Log("There is no enemy");
        }
    }
}
