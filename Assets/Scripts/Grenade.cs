using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ExplosionDamage(transform.position, 5f);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        LayerMask mask = LayerMask.GetMask("Player");
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, mask);
        foreach (var item in hitColliders)
        {
            Debug.Log(item);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, 5f);
    }
}
