using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float deathDelay = 1f;
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;
    public bool onFire = false;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    private void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        anim.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            isDead = true;
            FindObjectOfType<GameStatus>().ReduceEnemyCount();
            Death();
        }
    }



    public void Death()
    {
        anim.SetBool("IsDead", isDead);
        StartCoroutine(RemoveBody());
    }

    IEnumerator RemoveBody()
    {
        anim.SetTrigger("Die");
        deathDelay = deathDelay + anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        //Debug.Log("Removing body in " + deathDelay + " seconds");
        yield return new WaitForSeconds(deathDelay);
        //Debug.Log("Removing body");
        Destroy(gameObject);
    }
}
