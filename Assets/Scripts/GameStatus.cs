using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    sceneTransition sceneChanger;
    EnemySpawner[] listOfEnemies;
    [SerializeField] AudioClip winSfx;
    [SerializeField] AudioClip loseSfx;
    AudioSource audioPlayer;
    PlayerHealth player;
    public string winText;
    Text winMessage;
    int enemyCount = 0;
    Image background;
    public bool levelWon = false;
    public bool levelLost = false;

   

    // Use this for initialization
    void Start ()
    {
        background = GameObject.Find("MessageBackground").GetComponent<Image>();
        audioPlayer = GetComponent<AudioSource>();
        sceneChanger = GetComponent<sceneTransition>();
        winMessage = GameObject.Find("DeathMessage").GetComponent<Text>();

        if (sceneChanger.IsPlayScene())
        {
            FindObjectOfType<ScoreCounter>().ResetScore();
            Debug.Log("counting pigs and resetting scene scores");
            listOfEnemies = FindObjectsOfType<EnemySpawner>();
            CountEnemies(listOfEnemies);
            //FindObjectOfType<ScoreCounter>().ResetScore();
        }
        if (sceneChanger.GetCurrentScene() == 3)
        {
            FindObjectOfType<ScoreCounter>().ResetTotalScore();
        }

        if (sceneChanger.IsGameOver())
        {
            //Debug.Log("This should print in last scenes");
            FinalResult();
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
        //Debug.Log(enemyCount);
        if (enemyCount <= 0 && !FindObjectOfType<PlayerHealth>().isDead)
        {
            levelWon = true;
            WinLevel();
        }
        //Debug.Log("removing one enemy from list. Total amount of enemies remaining: " + enemyCount);
    }

    public void WinLevel()
    {
        if (!levelLost)
        {
            background.enabled = true;
            winText = " Winner is you \n score : " + FindObjectOfType<ScoreCounter>().score +
                        " \n TotalScore " + FindObjectOfType<ScoreCounter>().totalScore;
            //FindObjectOfType<ScoreCounter>().potentialScore;
            FindObjectOfType<ScoreCounter>().PotentialScoreToStars();
            audioPlayer.PlayOneShot(winSfx);
            StartCoroutine(LoadNextSceneWithDelayAndMessage(winText, 4f));
        }
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
        if (!levelWon)
        {
            background.enabled = true;
            audioPlayer.PlayOneShot(loseSfx);
            StartCoroutine(LoadGameOverScreenWithDelayAndMessage("You have just dieded", 4f));
        }
       
    }

    public void FinalResult()
    {
        background.enabled = true;
        winMessage.text = "";
        winMessage.text = "Final score : " + FindObjectOfType<ScoreCounter>().totalScore;
    }

}
