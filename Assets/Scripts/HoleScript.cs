using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {

    //public Collider player; // assign in inspector?
    //public TerrainCollider tCollider; // assign in inspector?
    public GameObject surface;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c);
        if (c.tag == "Enemy" || c.tag == "Player")
        {
            Debug.Log("YOU DO STUFF?");
            Physics.IgnoreCollision(c, surface.GetComponent<Collider>(), true);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Enemy" || c.tag == "Player")
        {
            Physics.IgnoreCollision(c, surface.GetComponent<Collider>(), false);
        }
    }
}
