using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    sceneTransition sceneChanger;
    EnemySpawner[] listOfEnemies;
    PlayerHealth player;
    [SerializeField] string winText = " Winner is you";
    Text winMessage;
    int enemyCount = 0;

	// Use this for initialization
	void Start ()
    {
        sceneChanger = GetComponent<sceneTransition>();
        winMessage = GameObject.Find("DeathMessage").GetComponent<Text>();
        listOfEnemies = FindObjectsOfType<EnemySpawner>();
        CountEnemies(listOfEnemies);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyCount <= 0 && !FindObjectOfType<PlayerHealth>().isDead)
        {
            //Debug.Log("Winner is you!");
            WinLevel();
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

    public void WinLevel()
    {
        StartCoroutine(LoadNextSceneWithDelayAndMessage(winText, 3f));
    }

    IEnumerator LoadNextSceneWithDelayAndMessage(string messageText, float delay)
    {
        winMessage.text = messageText;
        yield return new WaitForSeconds(delay);
        sceneChanger.LoadNextScene();
    }

    IEnumerator LoadGameOverScreenWithDelayAndMessage(string messageText, float delay)
    {
        winMessage.text = messageText;
        yield return new WaitForSeconds(delay);
        sceneChanger.LoadGameOver();
    }

    public void LoseGame()
    {
        StartCoroutine(LoadGameOverScreenWithDelayAndMessage("You have just dieded", 1f));
    }
}
