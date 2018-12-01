using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float deathDelay = 1f;
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;

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
            Death();
        }
    }



    public void Death()
    {
        // TODO: Death animation, or at least stop the enemy from chasing the player.
        anim.SetBool("IsDead", isDead);
        anim.SetTrigger("Die");
        deathDelay = deathDelay + anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        StartCoroutine(RemoveBody());
    }

    IEnumerator RemoveBody()
    {
        Debug.Log("You have slaughtered the enemy!");
        Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        Debug.Log("Removing body in " + deathDelay + " seconds");
        yield return new WaitForSeconds(deathDelay);
        Debug.Log("Removing body");
        Destroy(gameObject);
    }
}