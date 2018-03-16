using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Transform canvas;

	// Update is called once per frame
	private bool paused;
	public bool Paused
	{
		get{ return paused;}
		set{ paused = value;}
	}
	void Update () {
		pause();
	}
	public void pause()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;
				paused = true;
			} 
			else {
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
				paused = false;

			}
		}
	}
}
