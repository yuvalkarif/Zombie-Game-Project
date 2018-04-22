using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EducationalPopup : MonoBehaviour {

	public Transform EducationalCanvas;
	public Transform AnswerCanvas;
	List<Question> lst;
	public TextMeshProUGUI bt1,bt2,bt3,bt4,answer;
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
		lst.Add(new Question("The purpose of the immune system is to:"," Fight off sickness"," Help germs invade your body","Make your nose run","give you stomach aches"));
		lst.Add(new Question("The immune system is made up of:","All the Answers are correct","Cells","Organs","Tissues"));
		lst.Add(new Question("As part of the immune system, white blood cells fight germs. Another name for white blood cells is:","Leukocytes","Rhinovirus","Glands","Nodes"));
		lst.Add(new Question("white blood cells are found in lots of places, including an organ in your belly that filters blood and helps fight infections known as the:","Spleen","Heart","Kidneys","Brain"));
		lst.Add(new Question("The four main types of germs are:", "Viruses, bacteria, parasites, and fungi","Viruses, parasites, fungi, and phagocytes", "Parasites, bacteria, lymphocytes, and fungi","Small, medium, large, and extra large"));


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
			AnswerCanvas.gameObject.SetActive (true);
			EducationalCanvas.gameObject.SetActive (false);
			if(btn.text == lst[num].Ans )
			{
				player.changePoints(100);
				answer.text = "Correctly";
				Debug.Log("Correct");
			}
			else
				answer.text = "incorrectly";
			
			
	}
	public void Ret()
	{
		
		AnswerCanvas.gameObject.SetActive(false);
		Debug.Log("Closed");
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
		int x = 0 ;
		int rnd = Random.Range(0,btnList.Count);
		foreach(TextMeshProUGUI value in btnList)
		{
			if(i == rnd)
			{
				value.text = lst[pos].Ans;
			}
			else{
				
				value.text = lst[pos].WrongAns[x];
				x++;
			}
			i++;	
		}
	}
}
