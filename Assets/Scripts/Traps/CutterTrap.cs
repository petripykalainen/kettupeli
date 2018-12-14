using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterTrap : MonoBehaviour
{

    public int Damage = 10;
    public float timeBetweenAttacks = 0.5f;
    public float minWait = 1;
    public float maxWait = 5;
    public float spinTime = 3;
    private Animation anim;
    private MeshCollider coll;

    float timer;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animation>();
        coll = GetComponent<MeshCollider>();
        StartCoroutine(RandomWait());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator RandomWait()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            anim.Play();
            coll.isTrigger = true;
            yield return new WaitForSeconds(spinTime);
            coll.isTrigger = false;
            anim.Stop();
        }
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
