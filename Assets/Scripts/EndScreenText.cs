using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenText : MonoBehaviour {


    [SerializeField] Text finalText;
	// Use this for initialization
	void Start () {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings-1 )
        {
            finalText.text = "GAME OVER \n FINALSCORE \n" + FindObjectOfType<ScoreCounter>().totalScore;
        }

        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 2)
        {
            finalText.text = "CONGRATULATIONS \n YOU WON THE GAME\n FINALSCORE \n" + FindObjectOfType<ScoreCounter>().totalScore;
        }
        
    }
    void Update()
    {
        FindObjectOfType<ScoreCounter>().totalScore = 0;
    }

}
