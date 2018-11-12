using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] List<Transform> path;
    [SerializeField] float moveSpeed = 1f;
    public Transform chaseTarget;

    public Vector3 startingPosition;
    public bool playerInSight = false;

    int pathIndex = 0;

	// Use this for initialization
	void Start ()
    {
        startingPosition = transform.position;
	}

    public void SetTarget(Transform target)
    {
        chaseTarget = target;
    }

	// Update is called once per frame
	void Update ()
    {
        if (chaseTarget)
        {
            Chase(chaseTarget);
        }
        else
        {
            if (pathIndex <= path.Count - 1)
            {
                PatrolWaypoints();
            }
            else
            {
                ReturnToStart();
            }
        }
	}

    public void PatrolWaypoints()
    {
        Vector3 targetPosition = path[pathIndex].transform.position;
        Vector3 currentPosition = transform.position;
        float movement = moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, movement);
        if (currentPosition == targetPosition)
        {
            pathIndex++;
        }
    }

    public void ReturnToStart()
    { 
        
        Vector3 currentPosition = transform.position;
        float movement = moveSpeed * Time.deltaTime;

        if (currentPosition != startingPosition)
        {
            transform.position = Vector3.MoveTowards(currentPosition, startingPosition, movement);
        }
        else
        {
            pathIndex = 0;
        }
    }

    public void Chase(Transform target)
    {
        Vector3 currentPosition = transform.position;
        float movement = moveSpeed * Time.deltaTime;

        if (currentPosition != target.position)
        {
            transform.position = Vector3.MoveTowards(currentPosition, target.position, movement);
        }
    }
}
