using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

    public int score;
    public int totalScore;
    public int potentialScore;

    void Awake()
    {
        SetUpSingleton();
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

    // Use this for initialization
    void Start () {
        score = 0;
        totalScore = 0;
	}	
	// Update is called once per frame
	void Update () {
       
	}

    
}
