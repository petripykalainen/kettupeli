using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public Text deathMessage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public bool isDead;

    bool damaged;


    void Start()
    {
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        damageImage = GameObject.Find("DamageImage").GetComponent<Image>();
        deathMessage = GameObject.Find("DeathMessage").GetComponent<Text>();
        currentHealth = startingHealth;
        deathMessage.text = "";
    }


    void Update()
    {
        if (damaged)
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
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        Destroy(gameObject);
        deathMessage.text = "You have died!";
    }
}