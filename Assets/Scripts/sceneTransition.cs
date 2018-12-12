using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TÄMÄ PASKA EI SAA VAIHTUA VITTU
public class SceneTransition : MonoBehaviour {

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
    public void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadSpecificScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
