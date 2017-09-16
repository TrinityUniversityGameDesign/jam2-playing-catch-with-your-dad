using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

	public Canvas quitmenu;
	public Button play;
	public Button exit;

	// Use this for initialization
	void Start () {

		quitmenu = quitmenu.GetComponent<Canvas> (); 
		play = play.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();
		quitmenu.enabled = false;
	}

	public void ExitPress(){

		quitmenu.enabled = true;
		play.enabled = false;
		exit.enabled = false;
	}

	public void StartLevel(){
		SceneManager.LoadScene ("MainScene");
	}

	public void ExitGame(){
		Application.Quit (); 
	}

}
