using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour {

    [SerializeField] public float delay = 3f;
    [SerializeField] public float blastRadius = 5f;
    [SerializeField] public float explosionForce = 500f;

    public GameObject explosionEffect;

    [SerializeField] int damage = 100;

    [SerializeField]  float countdown;
    bool hasExploded = false;

	// Use this for initialization
	void Start () {
        countdown = delay;
    }
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
	}

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            EnemyHealth enem = nearbyObject.GetComponent<EnemyHealth>();
            if(enem != null)
            {
                enem.TakeDamage(damage);
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }

        Destroy(gameObject);
    }
}
