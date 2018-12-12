using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float deathDelay = 1f;
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;
    public bool onFire = false;
    [SerializeField] AudioClip deathSfx, hitSfx;
    [SerializeField] List<AudioClip> meleeSfx;
    AudioSource audioPlayer;

    Animator anim;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        anim.SetTrigger("Hit");
        audioPlayer.PlayOneShot(hitSfx);
        if (currentHealth <= 0)
        {
            isDead = true;
            FindObjectOfType<GameStatus>().ReduceEnemyCount();
            audioPlayer.PlayOneShot(deathSfx);
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

    public void PlayMeleeSound(List<AudioClip> sounds)
    {
        int index = UnityEngine.Random.Range(0, sounds.Count - 1);
        Debug.Log(sounds[index]);
        audioPlayer.PlayOneShot(sounds[index]);
    }
}
