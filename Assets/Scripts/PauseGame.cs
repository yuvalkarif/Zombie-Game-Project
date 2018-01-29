using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Transform canvas;

	// Update is called once per frame
	void Update () {
		pause();
	}
	public void pause()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive(true);
				Time.timeScale = 0;

			} 
			else {
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
			}
		}
	}
}
