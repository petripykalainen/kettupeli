using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private float move_x;
    private float move_y;
    private bool isAttacking;
    public Animator anim;
    GameObject player;
    Player playermovement;

	// Use this for initialization
	void Start () {
        playermovement = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
        }
        else {
            isAttacking = false;
            anim.SetBool("isAttacking", isAttacking);
        }
        if (player.GetComponent<PlayerHealth>().isDead == true)
        {
            anim.SetTrigger("Dead");
        }

        //move_x = Input.GetAxis("Horizontal");
        //move_y = Input.GetAxis("Vertical");

        //anim.SetFloat("move_x", move_x);
        //anim.SetFloat("move_y", move_y);
    }
}
