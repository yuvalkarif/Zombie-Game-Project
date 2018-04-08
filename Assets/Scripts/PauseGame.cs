using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour { // When the esc button is pressed it pauses the game and vice versa 

	public Transform pauseCanvas;
	public Transform settingCanvas;
	// Update is called once per frame
	private bool paused;
	public bool Paused
	{
		get{ return paused;}
		set{ paused = value;}
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && settingCanvas.gameObject.activeInHierarchy == false ) {
			pause ();
		}

	}
	public void pause() // pauses the game 
	{
		
		if (pauseCanvas.gameObject.activeInHierarchy == false) {
			pauseCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			paused = true;
		} else {
			pauseCanvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			paused = false;


		}
	}
	public void QuitGame() // Quits the game
	{
		Debug.Log ("Quit the game");
		Application.Quit();
		//TODO - when the game is turned into an app, check if the quit game func works 

	}
		
}
	