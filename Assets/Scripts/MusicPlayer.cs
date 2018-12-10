using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] List<AudioClip> musicList;
    AudioSource audioPlayer;

	// Use this for initialization
	void Awake ()
    {
        audioPlayer = GetComponent<AudioSource>();
        SetUpSingleton();
	}

    private void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("BUILD INDEX: " + scene.buildIndex);
        AudioClip audioClip = musicList[scene.buildIndex];

        //Debug.Log("Playing clip " + audioClip);

        if (audioClip && !IsSameAudio(audioClip))
        {
            audioPlayer.clip = audioClip;
            audioPlayer.loop = true;
            audioPlayer.Play();
        }
    }

    private bool IsSameAudio(AudioClip newAudio)
    {
        return newAudio == audioPlayer.clip;
    }

}
