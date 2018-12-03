using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private float move_x;
    private float move_y;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Input.GetKeyDown(""))
        {
            anim.Play("move", -1, 1.0f);
        }*/

        move_x = Input.GetAxis("Horizontal");
        move_y = Input.GetAxis("Vertical");
        anim.SetFloat("move_x", move_x);
        anim.SetFloat("move_y", move_y);
    }
}
