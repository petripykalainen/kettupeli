using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    [SerializeField] List<AudioClip> slashSounds;
    AudioSource audioPlayer;

	GameObject player;
    PlayerHealth playerHealth;

    bool enemyInRange;
    float timer;


    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //PlaySlashSFX();
            other.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            //Debug.Log(other.name);
        }
    }

    public void PlaySlashSFX()
    {
        int index = UnityEngine.Random.Range(0, slashSounds.Count);
        //Debug.Log(hitSfx[index]);
        audioPlayer.PlayOneShot(slashSounds[index]);
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
