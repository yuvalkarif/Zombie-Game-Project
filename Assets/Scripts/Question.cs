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
	private List<string> wrongAns;
	public List<string> WrongAns
	{
		get{return wrongAns;}
		set{wrongAns = value;}
	}
	public Question(string Question, string answer, string wrongAnswer, string wrongAnswer1, string wrongAnswer2)
	{
		wrongAns = new List<string>();
		this.ques = Question;
		this.ans = answer;
		this.wrongAns.Add( wrongAnswer);
		this.wrongAns.Add( wrongAnswer1);
		this.wrongAns.Add( wrongAnswer2);
		
	}
	
}
