using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class BoatswainCallQuestions : MonoBehaviour {
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect text;
	public Rect button1;
	public Rect button2;
	public Rect button3;
	public Rect button4;
	Rect playArea;
	int questionNumber;
	readonly int numberOfQuestions = 2;
	bool[] questions;
	
	// Use this for initialization
	void Start () {
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		questionNumber = 0;
		questions = new bool[numberOfQuestions];
		for(int i = 0; i < numberOfQuestions; i++){
			questions[i] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0:
			Question("Test Question", "One", "Two", "Three", "Four", 1);
			break;
		case 1:
			Question("Test Question 2", "One", "Two", "Three", "Four", 2);
			break;
		default:
			Question("There was a problem!", "One", "Two", "Three", "Four", 4);
			break;
		}
	}
	
	void Question(string question, string one, string two, string three, string four, int correct){
		GUI.BeginGroup(playArea);
		GUI.Label(new Rect(text), question);
		if(GUI.Button(new Rect(button1), one)){
			if(correct == 1)
				questions[questionNumber] = true;
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		if(GUI.Button(new Rect(button2), two)){
			if(correct == 2)
				questions[questionNumber] = true;
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		if(GUI.Button(new Rect(button3), three)){
			if(correct == 3)
				questions[questionNumber] = true;
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		if(GUI.Button(new Rect(button4), four)){
			if(correct == 4)
				questions[questionNumber] = true;
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		GUI.EndGroup();
	}
}
