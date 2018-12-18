using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    [SerializeField] List<GameObject> itemlist;
    [SerializeField] public float spawnDelay = 10f;
    public float timer = 0f;
    public bool itemSpawned = false;

	// Use this for initialization
	void Start ()
    {
        SpawnItem();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timer += Time.deltaTime;
        /*if(gameObject.name == "ItemSpawner")
        {
            Debug.Log("TIME ALLTIME: " + timer);
        }*/
        if (!itemSpawned && (timer >= spawnDelay))
        {
            SpawnItem();
        }
	}

    public void SpawnItem()
    {
        int randomIndex = Random.Range(0, itemlist.Count);
        //Debug.Log(randomIndex);
        Vector3 temp = new Vector3(transform.position.x, itemlist[randomIndex].transform.position.y, transform.position.z);
        Instantiate(
            itemlist[randomIndex],
            temp, //transform.position
            itemlist[randomIndex].transform.rotation); //Quaternion.identity

        //timer -= spawnDelay;
        itemSpawned = true;
    }
}
