using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    public GameObject finalScoreText;

	// Use this for initialization
	void Start () {

        finalScoreText = GameObject.Find("EndScore");
        finalScoreText.GetComponent<Text>().text = "Your Dad was Proud of You " + PlayerPrefs.GetFloat("finalscore") + " Times";

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
