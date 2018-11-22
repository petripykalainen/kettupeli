using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;

    public Vector3 startingPosition;


	// Use this for initialization
	void Start ()
    {
        startingPosition = transform.position;
	}

	// Update is called once per frame
	void Update ()
    {

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
