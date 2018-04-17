using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EducationalPopup : MonoBehaviour {

	public Transform EducationalCanvas;

	List<Question> lst;
	public TextMeshProUGUI bt1,bt2,bt3,bt4;
	//TODO : add a list of facts / questions 
	public int waveNum;
	WaveSpawner ws;
	public TextMeshProUGUI txt;
	List<TextMeshProUGUI> btnList;
	public int num;
	Player player ;
	public bool opened = false;
	void Start()
	{
		btnList = new List<TextMeshProUGUI>();
		btnList.Add(bt1);
		btnList.Add(bt2);
		btnList.Add(bt3);
		btnList.Add(bt4);
		ws =  GameObject.FindGameObjectWithTag("GameMaster").GetComponent<WaveSpawner>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		lst = new List<Question>();
		lst.Add(new Question("fact","answer"));
		lst.Add(new Question("fact2","answer2"));
		lst.Add(new Question("fact3","answer3"));
		lst.Add(new Question("fact4","answer4"));
		//waveNum = ws.WaveNumber;
		
	}
	public void openPopup()
	{

		
			EducationalCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			opened = true;
			ChangeQuestionText();
			
			
	} 
	public void closePopup(TextMeshProUGUI btn)
	{
			if(btn.text == lst[num].Ans )
			{
				player.changePoints(100);
				Debug.Log("Correct");
			}

			EducationalCanvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			
	}
	
	void Update()
	{
		if(ws.WaveNumber % waveNum == 0 && opened == false && ws.WaveNumber != 0)
		{
			openPopup();
		}
		else if(ws.WaveNumber % waveNum == 1 )
			opened = false;
	}
	public void ChangeQuestionText()
	{
		num = Random.Range(0 , lst.Count);
		txt.text = lst[num].Ques;
		ChangeAnswers(num);
	}
	public void ChangeAnswers(int pos)
	{
		int i = 0 ;
		int rnd = Random.Range(0,btnList.Count);
		foreach(TextMeshProUGUI value in btnList)
		{
			if(i == rnd)
			{
				value.text = lst[pos].Ans;
			}
			else{
				int x = Random.Range(0,lst.Count);
				while(x==pos)
				{
					x= Random.Range(0,lst.Count);
				}
				value.text = lst[x].Ans;
			}
			i++;	
		}
	}
}
