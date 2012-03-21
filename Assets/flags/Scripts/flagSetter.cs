using UnityEngine;
using System.Collections;
using System;
public class flagSetter : MonoBehaviour {
	
	// HUD
	public Texture2D[] flags;
	//public GUITexture flagGUI;
	public Texture2D flagGUI;
	// Use this for initialization
	private String[] flagnames = {"Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", 
		"Golf", "Hotel", "India", "Juliet", "Kilo", "Lima", "Mike", "November", "Oscar", 
		"Papa", "Quebec", "Romeo", "Sierra", "Tango", "Uniform", "Victor", "Whiskey", 
		"Xray", "Yankee", "Zulu"};
	
	private String[] answers = {"", "", "", ""};
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect text;
	public Rect answer;
	public Rect button1;
	public Rect button2;
	public Rect button3;
	public Rect button4;
	private Rect textNorm;
	private Rect answerNorm;
	private Rect button1Norm;
	private Rect button2Norm;
	private Rect button3Norm;
	private Rect button4Norm;
	private Rect playArea;
	private int correctAnswer = -1;
	private String answerText = "";
	
	//Question state
	int questionNumber;
	readonly int numberOfQuestions = 10;
	
	int numCorrect;
	
	static System.Random r = new System.Random();

    void buildQuestion()
	{
		for (int b = 0; b <= 3; b++)
		{
			answers[b] = "";
		}
		
		int n = r.Next() % 26;
	    flagGUI = flags[n];
        Debug.Log(n);
	    Debug.Log(flagnames[n]);
		int x = r.Next() % 4;
		Debug.Log(x);
		answers[x] = flagnames[n];
		correctAnswer = x;
		Debug.Log(answers[x]);
		
	    for (int i = 0; i <= 3; i++)
		{
			
			int k = r.Next() % 26;
			
			if(answers[i].Equals(""))
			{
				answers[i] = flagnames[k];
				while((i != 0 && answers[i].Equals(answers[0])) || (i != 1 && answers[i].Equals(answers[1])) || (i != 2 && answers[i].Equals(answers[2])) || (i != 3 && answers[i].Equals(answers[3])))
				{
					k = r.Next() % 26;
					answers[i] = flagnames[k];
					
				}
				
			}
			
					
		}
		
		/*
		for (int b = 0; b <= 3; b++)
		{
			Debug.Log("I'm in the last loop" + answers[b]);
		}
		*/
	}
	
	void Start () {
		
		buildQuestion();
	
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		questionNumber = 0;
		
		numCorrect = 0;
		textNorm = new Rect(text.x * playArea.width, text.y * playArea.height, text.width * playArea.width, text.height * playArea.height);
		answerNorm = new Rect(answer.x * playArea.width, answer.y * playArea.height, answer.width * playArea.width, answer.height * playArea.height);
		button1Norm = new Rect(button1.x * playArea.width, button1.y * playArea.height, button1.width * playArea.width, button1.height * playArea.height);
		button2Norm = new Rect(button2.x * playArea.width, button2.y * playArea.height, button2.width * playArea.width, button2.height * playArea.height);
		button3Norm = new Rect(button3.x * playArea.width, button3.y * playArea.height, button3.width * playArea.width, button3.height * playArea.height);
		button4Norm = new Rect(button4.x * playArea.width, button4.y * playArea.height, button4.width * playArea.width, button4.height * playArea.height);
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetTexture("_MainTex", flagGUI);
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		if(questionNumber < numberOfQuestions)	{
			Question("What is the raised flag?", answers[0], answers[1], answers[2], answers[3], correctAnswer);
			GUI.Label(new Rect(answerNorm), "Number correct: " + numCorrect + "\nNumber Wrong: " + (questionNumber-numCorrect) + "\nPrevious Correct answer: " + answerText);
			
		}
		else {
			
			Finish();
		}
		
	}
	
	
	
	void Question(string question, string one, string two, string three, string four, int correct){
		GUI.BeginGroup(playArea);
		GUI.Label(new Rect(textNorm), question);
		if(GUI.Button(new Rect(button1Norm), one)){
			if(correct == 0){
				
				numCorrect++;
				
			}
			
			if(questionNumber <= numberOfQuestions){
				answerText = answers[correct];
				buildQuestion();
				questionNumber++;
				
			}
			
		}
		if(GUI.Button(new Rect(button2Norm), two)){
			if(correct == 1){
				
				numCorrect++;
				
			}
			if(questionNumber <= numberOfQuestions){
				answerText = answers[correct];
				buildQuestion();
				questionNumber++;
			}
			
		}
		if(GUI.Button(new Rect(button3Norm), three)){
			if(correct == 2){
				
				numCorrect++;
			
			}
			if(questionNumber <= numberOfQuestions){
				answerText = answers[correct];
				buildQuestion();
				questionNumber++;
			}
		}
		if(GUI.Button(new Rect(button4Norm), four)){
			if(correct == 3){
				
				numCorrect++;
				
				
			}
			if(questionNumber <= numberOfQuestions){
				answerText = answers[correct];
				buildQuestion();
				questionNumber++;
			}
			
		}
		GUI.EndGroup();	
		
	}
	
	void Finish(){
		GUI.BeginGroup(playArea);
		int numbWrong = numberOfQuestions - numCorrect;
		GUI.Label(new Rect(textNorm), "Number correct: " + numCorrect + "\nNumber Wrong: " + numbWrong);
		if(GUI.Button(new Rect(button4Norm), "OK")){
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();
	}
}


