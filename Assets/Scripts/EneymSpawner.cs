using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneymSpawner : MonoBehaviour {

    public Enemy enemyprefab;
    public int enemyAmount = 3;
    public float spawnTime = 3f;
    public bool spawnComplete = false;
    public float timer;

	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        bool timeToSpawnEnemies = timer > spawnTime;
        if (timeToSpawnEnemies)
        {
            SpawnWave();
            timer = 0f;
        }
	}

    private void SpawnWave()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            StartCoroutine(CreateSingleEnemy());
        }
        spawnComplete = true;
    }

    IEnumerator CreateSingleEnemy()
    { 
        Debug.Log("Creating enemy");
        yield return new WaitForSeconds(spawnTime);
        Debug.Log("Enemy Created");
        GameObject.Instantiate(enemyprefab, transform.position, Quaternion.identity);
    }
}
