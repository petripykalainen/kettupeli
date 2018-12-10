using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    //public Text deathMessage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public bool isDead;
    public bool onFire = false;

    bool damaged;


    void Start()
    {
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
        var asd = FindObjectOfType<GameStatus>();
        Debug.Log(asd);
        asd.LoseGame();
        //deathMessage.text = "You have died!";
    }
}
