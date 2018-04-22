using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	// Use this for initialization
	public void PlayGame () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
		
	}
	
	// Update is called once per frame
	public void Quitgame()
	{
		Application.Quit();
	}
}
