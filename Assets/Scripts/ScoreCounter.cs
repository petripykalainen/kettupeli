using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    [SerializeField] List<Sprite> starimages;
    GameObject stardisplay;
    public int score = 0;
    public int totalScore = 0;
    public int potentialScore = 0;
    
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
            Debug.Log("HALLOO");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        stardisplay = GameObject.Find("StarDisplay");
	}	
	// Update is called once per frame
	void Update ()
    {
       
	}

    public void PotentialScoreToStars()
    {
        stardisplay = GameObject.Find("StarDisplay");
        int index = Mathf.FloorToInt(score / (potentialScore / 5));
        var starpicture = stardisplay.GetComponent<Image>();
        starpicture.enabled = true;
        starpicture.sprite = starimages[index-1];
    }

    public void ResetScore()
    {
        Debug.Log("RESETING SCORE");
        score = 0;
        potentialScore = 0;
    }

    public void ResetTotalScore()
    {
        Debug.Log("RESETING TOTALSCORE");
        totalScore = 0;
        potentialScore = 0;
        score = 0;
    }

    
}
