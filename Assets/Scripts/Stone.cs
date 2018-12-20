using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    List<Vector3> waypoints = new List<Vector3>();
    Vector3 rotation = Vector3.right;
    float speed = 0.3f;
    int waypointIndex = 0;
    float timer;

    public GameObject squash_effect;

    [SerializeField] float attackTimer = 1.0f;
    [SerializeField] int attackDamage = 15;

	// Use this for initialization
	void Start ()
    {
        Vector3 asd = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        waypoints.Add(asd);
        waypoints.Add(transform.position);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timer += Time.deltaTime;

        transform.RotateAround(transform.position, rotation, 3f);

        if (waypointIndex > 1)
        {
            waypointIndex = 0;
        }

        if (transform.position.z != waypoints[waypointIndex].z)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex], speed);
        }
        else
        {
            waypointIndex += 1;
            rotation = -rotation;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
        /*if (collision.transform.tag == "Pickup")
        {
            Debug.Log("suoritus");
            Instantiate(squash_effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }*/
    }
}
