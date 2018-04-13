using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationalPopup : MonoBehaviour {

	public Transform EducationalCanvas;

	//TODO : add a list of facts / questions 
	public int waveNum;
	WaveSpawner ws;
	public bool opened = false;
	void Start()
	{
		ws =  GameObject.FindGameObjectWithTag("GameMaster").GetComponent<WaveSpawner>();
		//waveNum = ws.WaveNumber;
		
	}
	public void Popup()
	{
		if (EducationalCanvas.gameObject.activeInHierarchy == false) {
			EducationalCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			opened = true;
			
		} 
		else {
			EducationalCanvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			


		}
	}
	void Update()
	{
		if(ws.WaveNumber % waveNum == 0 && opened == false && ws.WaveNumber != 0)
		{
			Popup();
		}
		else if(ws.WaveNumber % waveNum == 1 )
			opened = false;
	}
}
