using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private Transform playerPos;
    private Transform player;
    public GameObject item;

    private void Start()
    {
        //playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem()
    {
        Vector3 test = new Vector3(player.position.x, player.position.y + item.transform.position.y, player.position.z+2);

        //Instantiate(item, playerPos.position, Quaternion.identity); //Quaternion.identity, item spawns without rotation
        Instantiate(item, test, Quaternion.identity);
    }
}
