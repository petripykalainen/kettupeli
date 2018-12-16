using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public const int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    //public Text deathMessage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public bool isDead;
    public bool onFire = false;
    Animator anim;

    bool damaged;


    void Start()
    {
        anim = GameObject.Find("weasel_final_textured").GetComponent<Animator>();
        currentHealth = startingHealth;
        //deathMessage.text = "";
    }


    void Update()
    {
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
        int tempHealth = currentHealth;
        currentHealth -= amount;
        if (currentHealth < tempHealth ) { damaged = true; }
        healthSlider.value = currentHealth;
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        anim.SetTrigger("Dead");
        anim.SetBool("isDead", isDead);

        var asd = FindObjectOfType<GameStatus>();
        Debug.Log(asd);
        asd.LoseGame();
        //deathMessage.text = "You have died!";
    }
}
