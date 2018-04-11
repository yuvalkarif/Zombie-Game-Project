using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationalPopup : MonoBehaviour {

	public Transform EducationalCanvas;

	//TODO : add a list of facts / questions 
	public int waveNum = 0;
	WaveSpawner ws;

	void Start()
	{
		ws =  GameObject.FindGameObjectWithTag("GameMaster").GetComponent<WaveSpawner>();
		waveNum = ws.WaveNumber;
	}
	public void Popup()
	{
		if (EducationalCanvas.gameObject.activeInHierarchy == false) {
			EducationalCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			
		} 
		else {
			EducationalCanvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			


		}
	}
	void Update()
	{
		
	}
}
