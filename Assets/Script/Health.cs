using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    [SerializeField] RectTransform healthBar; // Source must be Foreground
    [SerializeField] Text hitPoints;
    [SerializeField] Text deathMessage;

    void Start()
    {
<<<<<<< HEAD
<<<<<<< Updated upstream
<<<<<<< HEAD
        healthBar = GameObject.Find("Healthbar Canvas/Background/Foreground").GetComponent<RectTransform>();
        hitPoints = GameObject.Find("Healthbar Canvas/Background/Hitpoints").GetComponent<Text>();
        deathMessage = GameObject.Find("Healthbar Canvas/Death Text").GetComponent<Text>();
=======
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        //healthBar = GameObject.Find("Healthbar Canvas/Background/Foreground").GetComponent<RectTransform>();
        //hitPoints = GameObject.Find("Healthbar Canvas/Background/Hitpoints").GetComponent<Text>();
        //deathMessage = GameObject.Find("Healthbar Canvas/Death Text").GetComponent<Text>();

<<<<<<< Updated upstream
>>>>>>> Stashed changes
>>>>>>> petri
=======
>>>>>>> Stashed changes
=======
        healthBar = GameObject.Find("Healthbar Canvas/Background/Foreground").GetComponent<RectTransform>();
        hitPoints = GameObject.Find("Healthbar Canvas/Background/Hitpoints").GetComponent<Text>();
        deathMessage = GameObject.Find("Healthbar Canvas/Death Text").GetComponent<Text>();
>>>>>>> 929347d30084e42cdd72ea2ac09423ed39ac6abd
        SetHitPoints();
        deathMessage.text = "";
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }

        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);

        if (other.gameObject.CompareTag("Enemy"))
        {

            var health = GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(10);
            }
            SetHitPoints();
        }
    }
    void SetHitPoints()
    {
        hitPoints.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        if (currentHealth <= 0)
        {
            deathMessage.text = "You have died!";
        }
    }
}
