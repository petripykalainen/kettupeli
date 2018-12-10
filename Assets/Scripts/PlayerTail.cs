using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            Rigidbody enemyRB = other.GetComponent<Rigidbody>();
            GameObject player = GameObject.Find("Player");
            Vector3 direction = other.transform.position - player.transform.position;
            enemyRB.AddForce(Vector3.up * 2000);
            enemyRB.useGravity = true;
        }
    }
}
