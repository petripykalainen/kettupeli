using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    sceneTransition sceneChanger;
    EnemySpawner[] listOfEnemies;
    PlayerHealth player;    
    [SerializeField] string winText = " Winner is you ";
    Text winMessage;
    int enemyCount = 0;

    // Use this for initialization
    void Start ()
    {
        sceneChanger = GetComponent<sceneTransition>();
        winMessage = GameObject.Find("DeathMessage").GetComponent<Text>();

        if (sceneChanger.IsPlayScene())
        {
            listOfEnemies = FindObjectsOfType<EnemySpawner>();
            CountEnemies(listOfEnemies);
            FindObjectOfType<ScoreCounter>().score = 0;
            FindObjectOfType<ScoreCounter>().potentialScore = 0;
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
        Debug.Log(enemyCount);
        if (enemyCount <= 0 && !FindObjectOfType<PlayerHealth>().isDead)
        {
            WinLevel();
        }
        //Debug.Log("removing one enemy from list. Total amount of enemies remaining: " + enemyCount);
    }

    public void WinLevel()
    {
        winText = " Winner is you \n score : " + FindObjectOfType<ScoreCounter>().score +
                  " \n TotalScore " + FindObjectOfType<ScoreCounter>().totalScore;
        //FindObjectOfType<ScoreCounter>().potentialScore;
        FindObjectOfType<ScoreCounter>().PotentialScoreToStars();
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
        StartCoroutine(LoadGameOverScreenWithDelayAndMessage("You have just dieded", 3f));
    }

}
