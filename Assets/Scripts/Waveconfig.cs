using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Waveconfig")] 
public class Waveconfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 0.5f;
    [SerializeField] float spawnVariationTime = 0.3f;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float spawnDuration = 10f;

    public GameObject GetEnemy() { return enemyPrefab; }
    public float GetSpawnTime() { return spawnTimer; }
    public float GetSpawnTimeVariation() {return spawnVariationTime; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetSpawnDuration() { return spawnDuration; }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
