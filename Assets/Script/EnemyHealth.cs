using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;

    CapsuleCollider capsuleCollider;


    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    void Update()
    {

    }


    public void TakeDamage(int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        // TODO: Death animation, or at least stop the enemy from chasing the player.
        isDead = true;
        Debug.Log("You have slaughtered the enemy!");
        // capsuleCollider.isTrigger = true;    
    }
}