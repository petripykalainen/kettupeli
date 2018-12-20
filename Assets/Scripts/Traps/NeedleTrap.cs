using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleTrap : MonoBehaviour
{

    public int Damage = 25;
    public float maxWait = 5;
    public float minWait = 1;
    private Animation anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animation>();
        StartCoroutine(RandomWait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator RandomWait()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            anim.Play();
        }
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
