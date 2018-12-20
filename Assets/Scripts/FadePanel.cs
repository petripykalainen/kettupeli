using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour {

    [SerializeField] float fadeInTime = 2f;
    GameObject playButton, quitButton;
    public Image fadePanel;
    public Color currentColor = Color.black;
    //public Color buttonColor;

	// Use this for initialization
	void Start ()
    {
        fadePanel = GetComponent<Image>();
        fadePanel.enabled = true;
        //playButton = GameObject.Find("PlayText");
        //quitButton = GameObject.Find("QuitText");
        //buttonColor = playButton.GetComponent<Text>().color;
        //playButton.GetComponent<Text>().color = buttonColor - buttonColor;
        //quitButton.GetComponent<Text>().color = buttonColor - buttonColor;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float change = Time.deltaTime / fadeInTime;
            currentColor.a -= change;
            //buttonColor.a += change;
            fadePanel.color = currentColor;
            //playButton.GetComponent<Text>().color = buttonColor;
            //quitButton.GetComponent<Text>().color = buttonColor;

        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
