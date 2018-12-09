using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    EnemySpawner[] listOfEnemies;
    [SerializeField] string winText = " Winner is you";
    Text winMessage;
    int enemyCount = 0;

	// Use this for initialization
	void Start ()
    {
        winMessage = GameObject.Find("DeathMessage").GetComponent<Text>();
        Debug.Log(winMessage);
        winMessage.text = winText;
        listOfEnemies = FindObjectsOfType<EnemySpawner>();
        CountEnemies(listOfEnemies);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyCount <= 0)
        {
            Debug.Log("Winner is you!");
            winGame();
        }
	}

    private void CountEnemies(EnemySpawner[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            //Debug.Log(enemies[i].GetEnemyCount());
            enemyCount += enemies[i].GetEnemyCount();
        }
    }

    public void ReduceEnemyCount()
    {
        enemyCount -= 1;
        Debug.Log("removing one enemy from list. Total amount of enemies remaining: " + enemyCount);
    }

    public void winGame()
    {
        winMessage.text = winText;
    }
}
