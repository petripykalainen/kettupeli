using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterTrap : MonoBehaviour
{

    public int Damage = 10;
    public float timeBetweenAttacks = 0.5f;

    float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        GameObject objectCollided = other.gameObject;
        if (timer >= timeBetweenAttacks)
        {
            if (objectCollided.CompareTag("Enemy"))
            {
                objectCollided.GetComponent<EnemyHealth>().TakeDamage(Damage);
            }
            else if (objectCollided.CompareTag("Player"))
            {
                objectCollided.GetComponent<PlayerHealth>().TakeDamage(Damage);
            }
            timer = 0f;
        }

    }
}
