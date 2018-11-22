using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    Vector3 offset;
    Transform player;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").transform.GetChild(0);
        //Debug.Log("Found " + player);
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void LateUpdate()
    {
        UpdateCameraPosition();
    }

    public void UpdateCameraPosition()
    {
        transform.position = player.transform.position + offset;
    }
}
