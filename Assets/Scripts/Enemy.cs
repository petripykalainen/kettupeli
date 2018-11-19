using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float visionLength = 30f;
    public Vector3 target;
    public Vector3 originPoint;
    public GameObject player;
    public bool playerInRange;
    public bool playerIsVisible;

	// Use this for initialization
	void Start ()
    {
        playerInRange = false;
        playerIsVisible = false;
        player = FindObjectOfType<Player>().gameObject;
        originPoint = transform.position;
    }

	// Update is called once per frame
	void Update ()
    {
        if (playerInRange && playerIsVisible)
        {
            Debug.Log("Chasing Player");
        }
        if (playerInRange && !playerIsVisible)
        {
            ScoutForPlayer();
        }
	}

    /*
    public void DrawDebugRays()
    {
        if (playerInRange)
        {

        }
        RaycastHit hit;
        Vector3 targetPosition = player.transform.position - transform.position;
        Vector3 position = transform.position + Vector3.up;
        LayerMask mask = LayerMask.GetMask("World");
        Color raycolor = Color.yellow;

        if (Physics.Raycast(position, targetPosition, out hit, visionLength,mask))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("Chasing Player!");
                MoveTo(targetPosition);
                Debug.DrawRay(position, targetPosition, Color.red, 0.5f);
            }
            else
            {
                Debug.Log("Going back.");
                MoveTo(originPoint);
            }
        }
        else
        {

            Debug.Log("Going back.");
            MoveTo(originPoint);
  
        }

    }
    */

    public void ScoutForPlayer()
    {
        RaycastHit hit;
        Vector3 targetPosition = player.transform.position - transform.position;
        Vector3 position = transform.position + Vector3.up;
        LayerMask mask = LayerMask.GetMask("World");

        if (!Physics.Raycast(position, targetPosition, out hit, visionLength, mask))
        {
            Debug.Log("Player is visible");
            playerIsVisible = true;
            Debug.DrawRay(position, targetPosition, Color.red, 2f);
        }
        else
        {
            playerIsVisible = false;
        }
    }

    public void MoveTo(Vector3 target)
    {
        Vector3 currentPosition = transform.position;
        float movement = moveSpeed * Time.deltaTime;

        if (currentPosition != target)
        {
            transform.position = Vector3.MoveTowards(currentPosition, target, movement);
        }
    }

    IEnumerator StopChase()
    {
        float wait = Random.Range(0.6f, 2f);

        yield return new WaitForSeconds(wait);

        if (!playerInRange && !playerIsVisible)
        {
            target = originPoint;
        }
    }

    public void GiveUpChase()
    {
        if (!playerInRange && !playerIsVisible)
        {
            target = originPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            playerInRange = true;

            Debug.Log(other.name + " Entered.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            playerInRange = false;
            Debug.Log(other.name + " Left.");
            if (!playerIsVisible)
            {
                Debug.Log("Maybe I lost him.");
                GiveUpChase();
            }
        }
    }
}
