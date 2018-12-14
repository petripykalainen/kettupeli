using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    public int Damage = 5;
    public int tickAmount = 4;
    public float timeBetweenTicks = 1.0f;
    public float minWait = 1;
    public float maxWait = 3;
    public float burnTime = 5;
    private ParticleSystem eff;


    // Use this for initialization
    void Start()
    {
        eff = GetComponent<ParticleSystem>();
        StartCoroutine(RandomWait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy") && !other.GetComponent<EnemyHealth>().onFire)
        {
            StartCoroutine(DamageOverTimeEnemy(other));
        }
        else if (other.CompareTag("Player") && !other.GetComponent<PlayerHealth>().onFire)
        {
            StartCoroutine(DamageOverTimePlayer(other));
        }

    }

    IEnumerator RandomWait()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            eff.Play();
            yield return new WaitForSeconds(burnTime);
            eff.Stop();
        }
    }

    IEnumerator DamageOverTimePlayer(GameObject other)
    {
        other.GetComponent<PlayerHealth>().onFire = true;
        int currentCount = 0;
        while (currentCount <= tickAmount)
        {
            ParticleSystem fire = other.GetComponentInChildren<ParticleSystem>();
            fire.Play();
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
            yield return new WaitForSeconds(timeBetweenTicks);
            fire.Stop();
            currentCount++;
        }
        other.GetComponent<PlayerHealth>().onFire = false;
    }

    IEnumerator DamageOverTimeEnemy(GameObject other)
    {
        other.GetComponent<EnemyHealth>().onFire = true;
        int currentCount = 0;
        while (currentCount <= tickAmount)
        {
            ParticleSystem fire = other.GetComponentInChildren<ParticleSystem>();
            fire.Play();
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);
            yield return new WaitForSeconds(timeBetweenTicks);
            fire.Stop();
            currentCount++;
        }
        other.GetComponent<EnemyHealth>().onFire = false;
    }
}
