using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] List<Transform> path;
    [SerializeField] float moveSpeed = 1f;
    Vector3 startingPosition;

    int pathIndex = 0;

	// Use this for initialization
	void Start ()
    {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pathIndex <= path.Count - 1)
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
        else
        {
            ReturnToStart();
        }
	}

    public void ReturnToStart()
    { 
        Vector3 targetPosition = path[0].transform.position;
        Vector3 currentPosition = transform.position;
        float movement = moveSpeed * Time.deltaTime;

        if (currentPosition != targetPosition)
        {
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, movement);
        }
        else
        {
            pathIndex = 0;
        }
    }
}
