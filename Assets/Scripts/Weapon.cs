using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public PlayerHealth player;
    public EnemyAttack enemyAttack;
    private bool playerWasHit = false;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        enemyAttack = GameObject.Find("PigmanAnimated").GetComponent<EnemyAttack>();
        Debug.Log(player);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerWasHit = !playerWasHit;
            if (playerWasHit)
            {
                //Debug.Log(other.name);
                player.TakeDamage(enemyAttack.attackDamage);
            }
        }
    }
}
