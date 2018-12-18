using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    AudioSource audioPlayer;
    public AudioClip shieldAudio;
    [SerializeField] List<AudioClip> hitSFX;
    [SerializeField] List<AudioClip> deathFX;
    public int startingHealth = 100;
    public const int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    //public Text deathMessage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public bool isDead = false;
    public bool onFire = false;
    public bool activeShield = false;
    public float shieldTime = 5f;

    private GameObject shield_effects;
    private ParticleSystem shield_top;
    private ParticleSystem shield_bot;
    Animator anim;

    bool damaged;


    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        anim = GameObject.Find("weasel_final_textured").GetComponent<Animator>();
        shield_effects = GameObject.Find("Shield_effects");
        shield_top = shield_effects.transform.GetChild(0).GetComponent<ParticleSystem>();
        shield_bot = shield_effects.transform.GetChild(1).GetComponent<ParticleSystem>();
        currentHealth = startingHealth;

        //deathMessage.text = "";
    }


    void Update()
    {
        if(transform.position.y < -20 && !isDead)
        {
            TakeDamage(maxHealth);
        }
        if (damaged && currentHealth > 0)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        if (!activeShield)
        {
            int tempHealth = currentHealth;
            currentHealth -= amount;
            if (currentHealth < tempHealth)
            {
                damaged = true;
                int index = Random.Range(0, hitSFX.Count);
                audioPlayer.PlayOneShot(hitSFX[index]);
            }
            healthSlider.value = currentHealth;
            if (currentHealth > maxHealth) { currentHealth = maxHealth; }
            if (currentHealth <= 0 && !isDead)
            {
                int index = Random.Range(0, deathFX.Count);
                audioPlayer.PlayOneShot(deathFX[index]);
                Death();
            }
        }
    }


    void Death()
    {
        isDead = true;

        anim.SetTrigger("Dead");
        anim.SetBool("isDead", isDead);

        var asd = FindObjectOfType<GameStatus>();
        //Debug.Log(asd);
        asd.levelLost = true;
        asd.LoseGame();
        //deathMessage.text = "You have died!";
    }

    public void ShieldActivation()
    {
        activeShield = true;
        audioPlayer.PlayOneShot(shieldAudio, 1f);
        shield_top.Play();
        shield_bot.Play();
        Debug.Log("shield active :o");
        StartCoroutine(ShieldDeactivate());
    }

    IEnumerator ShieldDeactivate()
    {
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        //Debug.Log("Removing body in " + deathDelay + " seconds");
        yield return new WaitForSeconds(shieldTime);
        Debug.Log("shield deactivated");
        activeShield = false;
        shield_top.Stop();
        shield_bot.Stop();
    }
}
