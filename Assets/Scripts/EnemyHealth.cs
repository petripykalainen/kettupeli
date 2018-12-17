using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float deathDelay = 1f;
    [SerializeField] public int scoreForKill = 100;
    float timeAlive;
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead = false;
    public bool onFire = false;
    [SerializeField] AudioClip deathSfx, hitSfx;
    [SerializeField] List<AudioClip> meleeSfx;
    AudioSource audioPlayer;
    public GameObject bacon;

    Animator anim;

    void Start()
    {
        FindObjectOfType<ScoreCounter>().potentialScore += scoreForKill * 3;
        timeAlive = 0f;
        audioPlayer = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }
    private void Update()
    {
        timeAlive += Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        anim.SetTrigger("Hit");
        audioPlayer.PlayOneShot(hitSfx);
        if (currentHealth < 0)
        {
            Death();
        }
    }



    public void Death()
    {
        FindObjectOfType<ScoreCounter>().score += ActualScore(scoreForKill);
        FindObjectOfType<ScoreCounter>().totalScore += ActualScore(scoreForKill);
        FindObjectOfType<GameStatus>().ReduceEnemyCount();
        isDead = true;
        audioPlayer.PlayOneShot(deathSfx);
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
        if (bacon != null)
        {
            Instantiate(bacon, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void PlayMeleeSound(List<AudioClip> sounds)
    {
        int index = UnityEngine.Random.Range(0, sounds.Count - 1);
        Debug.Log(sounds[index]);
        audioPlayer.PlayOneShot(sounds[index]);
    }

    public int ActualScore(int score)
    {
        // jos muutatte kertojia, muuttakaa potentialscore start funktiossa
        if (timeAlive < 3.5f){ score *= 3; }
        else if (timeAlive < 6f) { score *= 2; }
        else if (timeAlive < 10f) { score /= 2; }
        return score;
    }
}
