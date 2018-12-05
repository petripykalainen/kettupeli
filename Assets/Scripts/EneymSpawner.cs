using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneymSpawner : MonoBehaviour {

    [SerializeField] List<Waveconfig> waveconfig;
    int spawnIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnEnemyWave(Waveconfig wave)
    {
        for (int i = 0; i < wave.GetNumberOfEnemies(); i++)
        {
            Instantiate(
            wave.GetEnemy(),
            transform.position,
            Quaternion.identity);
            yield return new WaitForSeconds(wave.GetSpawnTime());
        }
        yield return new WaitForSeconds(wave.GetSpawnDuration());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = spawnIndex; i < waveconfig.Count ; i++)
        {
            var currentWave = waveconfig[spawnIndex];
            yield return StartCoroutine(SpawnEnemyWave(waveconfig[i]));
        }
    }
}
