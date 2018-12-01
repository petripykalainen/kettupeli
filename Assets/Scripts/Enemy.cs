using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float stoppingDistance = 2.4f;
    public EnemyHealth health;
    public EnemyAttack attack;
    public Vector3 startingPosition;
    public Animator anim;
    public GameObject player;

    private NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        attack = GetComponent<EnemyAttack>();
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;
	}

	// Update is called once per frame
	void Update ()
    {
        if (health.isDead)
        {
            agent.ResetPath();
        }
        else
        {
            bool inAttackRange = Vector3.Distance(transform.position, player.transform.position) <= stoppingDistance;
            anim.SetBool("Walking", !inAttackRange);
            if (player)
            {
                if (inAttackRange)
                {
                    agent.ResetPath();
                    attack.Attack();
                }
                else
                {
                    agent.SetDestination(player.transform.position);
                }
                //Charge();
                //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            }
        }
	}

    private void Charge()
    {
        if (player)
        {
            bool playerInRange = Vector3.Distance(transform.position, player.transform.position) <= stoppingDistance;
            Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            //bool timeToAttack = timer >= timeBetweenAttacks;
            anim.SetBool("Charging", !playerInRange);
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
