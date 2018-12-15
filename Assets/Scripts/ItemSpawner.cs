using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    [SerializeField] List<GameObject> itemlist;
    [SerializeField] float spawnDelay = 10f;
    float timer = 0f;
    public bool itemSpawned = false;

	// Use this for initialization
	void Start ()
    {
        SpawnItem();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (!itemSpawned && timer >= spawnDelay)
        {
            SpawnItem();
        }
	}

    public void SpawnItem()
    {
        int randomIndex = Random.Range(0, itemlist.Count - 1);
        Instantiate(
            itemlist[randomIndex],
            transform.position,
            Quaternion.identity);
        itemSpawned = true;
        timer = 0f;
        Debug.Log("Spawned " + itemlist[randomIndex].name);
    }
}
