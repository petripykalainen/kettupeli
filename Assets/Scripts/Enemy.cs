using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float stoppingDistance = 2.4f;
    public Vector3 startingPosition;
    public Animator anim;
    public GameObject player;

    private NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        bool inAttackRange = Vector3.Distance(transform.position, player.transform.position) <= stoppingDistance;

        if (player)
        {
            if (inAttackRange)
            {
                agent.ResetPath();
            }
            else
            {
                agent.SetDestination(player.transform.position);
            }
            anim.SetBool("aggressive_walk", !inAttackRange);
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        }
	}

    ///<summary>
    ///If not in position target, move there
    ///</summary>
    public void MoveTo(Vector3 target)
    {
        Vector3 currentPosition = transform.position;
        float movement = moveSpeed * Time.deltaTime;

        if (currentPosition != target)
        {
            transform.position = Vector3.MoveTowards(currentPosition, target, movement);
        }
    }
}
