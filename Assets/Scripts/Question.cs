using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour {

	private string ques;
	public string Ques
	{
		get{return ques;}
		set{ques= value;}
	}
	private string ans; 
	public string Ans
	{
		get{return ans;}
		set{ans = value;}
	}
	public Question(string Question, string answer)
	{
		this.ques = Question;
		this.ans = answer;
	}
	
}
