using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    int currentSceneIndex;
    AudioSource audioPlayer;
    [SerializeField] float startDelay = 1.5f;
    [SerializeField] AudioClip importantMenuSound;
    SceneTransition sceneChanger;
    [SerializeField] int timeToWait = 4;
	
    // Use this for initialization
	void Start ()
    {
        audioPlayer = GetComponent<AudioSource>();
        sceneChanger = GetComponent<SceneTransition>();
        currentSceneIndex = sceneChanger.GetCurrentScene();
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadFromSplashWithDelay());
        }
	}

    IEnumerator LoadFromSplashWithDelay()
    {
        yield return new WaitForSeconds(timeToWait);
        sceneChanger.LoadNextScene();
    }

    IEnumerator LoadNextWithDelay(float delay)
    {
        audioPlayer.PlayOneShot(importantMenuSound);
        Debug.Log("VITTU");
        yield return new WaitForSeconds(delay);
        Debug.Log("saatana");
        sceneChanger.LoadNextScene();
    }

    public void LoadFirstLevel()
    {
        //StartCoroutine(LoadNextWithDelay(startDelay));
        Debug.Log("VITTU");
        audioPlayer.PlayOneShot(importantMenuSound);
        Debug.Log("saatana");
        sceneChanger.LoadNextScene();
    }

}
