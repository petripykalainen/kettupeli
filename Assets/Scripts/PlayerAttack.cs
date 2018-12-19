using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public bool damageIncrease = false;
    [SerializeField] List<AudioClip> slashSounds;
    AudioSource audioPlayer;

    GameObject weaponEffect;
	GameObject player;
    PlayerHealth playerHealth;

    bool enemyInRange;
    float timer;


    void Start()
    {
        weaponEffect = GameObject.Find("SwordFlameEffect");
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
            if (damageIncrease)
            {
                if (other.CompareTag("Enemy") && !other.GetComponent<EnemyHealth>().onFire)
                {
                    StartCoroutine(DamageOverTime(other.gameObject));
                }
            }
            //Debug.Log(other.name);
        }
    }

    public void PlaySlashSFX()
    {
        int index = UnityEngine.Random.Range(0, slashSounds.Count);
        //Debug.Log(hitSfx[index]);
        audioPlayer.PlayOneShot(slashSounds[index]);
    }

    public void DamageBoost()
    {
        damageIncrease = true;
        weaponEffect.GetComponentInChildren<ParticleSystem>().Play();
        StartCoroutine(DamageBoostDeactivate());
    }

    IEnumerator DamageOverTime(GameObject other)
    {
        other.GetComponent<EnemyHealth>().onFire = true;
        int currentCount = 0;
        ParticleSystem fire = other.GetComponentInChildren<ParticleSystem>();
        fire.Play();
        while (currentCount <= 4)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(attackDamage - 5);
            yield return new WaitForSeconds(1.0f);
            //fire.Stop();
            currentCount++;
        }
        other.GetComponent<EnemyHealth>().onFire = false;
    }

    IEnumerator DamageBoostDeactivate()
    {
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        //Debug.Log("Removing body in " + deathDelay + " seconds");
        yield return new WaitForSeconds(5f);
        damageIncrease = false;
        weaponEffect.GetComponentInChildren<ParticleSystem>().Stop();
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
