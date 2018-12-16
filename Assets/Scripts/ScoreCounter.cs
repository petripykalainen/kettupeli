using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    [SerializeField] List<Sprite> starimages;
    GameObject stardisplay;
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
    void Start ()
    {
        stardisplay = GameObject.Find("StarDisplay");
        score = 0;
        totalScore = 0;
	}	
	// Update is called once per frame
	void Update ()
    {
       
	}

    public void PotentialScoreToStars()
    {
        int index = Mathf.FloorToInt(score / (potentialScore / 5));
        var starpicture = stardisplay.GetComponent<Image>();
        starpicture.enabled = true;
        starpicture.sprite = starimages[index-1];
    }

    
}
