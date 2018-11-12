using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar; // Source must be Foreground
    public Text hitPoints;
    public Text deathMessage;

    void Start()
    {
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
        if (other.gameObject.CompareTag("DamageSource"))
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
