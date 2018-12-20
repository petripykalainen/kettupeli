using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    Vector3 offset;
    Transform player;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").transform;
        //Debug.Log("Found " + player);
        transform.position += player.position;
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        UpdateCameraPosition();
    }

    public void UpdateCameraPosition()
    {
        transform.position = player.position + offset;
    }
}
