using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleTrap : MonoBehaviour
{

    public int Damage = 25;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        GameObject objectCollided = other.gameObject;
        if (objectCollided.CompareTag("Enemy"))
        {
            objectCollided.GetComponent<EnemyHealth>().TakeDamage(Damage);
        }
        else if (objectCollided.CompareTag("Player"))
        {
            objectCollided.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }

    }
}
