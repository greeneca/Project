using UnityEngine;
using System.Collections;

public class bellQuestions : MonoBehaviour {

	//station UID
	public readonly int stationID = 2;
	
	//Feedback
	public GUITexture checkmark;
	public GUITexture xmark;
	

	public GUITexture arrow1;
	public GUITexture arrow2;
	public GUITexture arrow3;
	
	//GUI Stuff
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect text;
	public Rect score;
	public Rect button1;
	public Rect button2;
	public Rect button3;
	public Rect button4;
	public Rect buttonQuit;
	private Rect textNorm;
	private Rect scoreNorm;
	private Rect button1Norm;
	private Rect button2Norm;
	private Rect button3Norm;
	private Rect button4Norm;
	private Rect buttonQuitNorm;
	private Rect playArea;
	
	//Question state
	int questionNumber;
	int lastQuestion;
	readonly int numberOfQuestions = 10;
	readonly int passNumber = 7;
	int numCorrect;
	
	//Style for labels
	private GUIStyle style = new GUIStyle();
	
	//Locks
	private bool doOnce;
	private bool isLocked;
	private bool arrowLock;
	
	
	
	
		
	// Use this for initialization
	void Start () {		
		//init locks
		doOnce = true;
		isLocked = false;
		arrowLock = false;
		//init question vars
		questionNumber = 0;
		lastQuestion = -1;
		numCorrect = 0;
		//init gui areas
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		textNorm = new Rect(text.x * playArea.width, text.y * playArea.height, text.width * playArea.width, text.height * playArea.height);
		scoreNorm = new Rect(score.x * playArea.width, score.y * playArea.height, score.width * playArea.width, score.height * playArea.height);
		button1Norm = new Rect(button1.x * playArea.width, button1.y * playArea.height, button1.width * playArea.width, button1.height * playArea.height);
		button2Norm = new Rect(button2.x * playArea.width, button2.y * playArea.height, button2.width * playArea.width, button2.height * playArea.height);
		button3Norm = new Rect(button3.x * playArea.width, button3.y * playArea.height, button3.width * playArea.width, button3.height * playArea.height);
		button4Norm = new Rect(button4.x * playArea.width, button4.y * playArea.height, button4.width * playArea.width, button4.height * playArea.height);
		buttonQuitNorm = new Rect(buttonQuit.x * playArea.width, buttonQuit.y * playArea.height, buttonQuit.width * playArea.width, buttonQuit.height * playArea.height);
		//init style
		style.fontSize = 18;
		style.normal.textColor = Color.white;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		
		
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0:
			
			//Debug.Log("Question 1");
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			if(!arrowLock)
			StartCoroutine("displayArrow",1);
			Question("Question 1: \nWhat is this part of the bell?", "Bell", "Clapper", "Bell Rope", "Frame", 1);
			break;
		case 1:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			displayArrow(3);
			Question("Question 2:\nWhat is this part of the bell?", "Bell", "Clapper", "Bell Rope", "Frame", 3);
			break;
		case 2:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			displayArrow(3);
			Question("Question 3:\nWhat is this part of the bell?", "Bell", "Clapper", "Bell Rope", "Frame", 2);
			break;
		case 3:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			Question("Question 4:\nIf the time were 1100, would an even or odd number \nof bells be rung?", "", "Odd", "Even", "", 3);
			break;
		case 4:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			Question("Question 5:\nWhat is the maximum number of bells you \nwill hear at one time?", "One", "Six", "Eight", "Three", 3);
			break;
		case 5:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			Question("Question 6:\nHow many times is the bell rung for 0800?", "Seven", "Six", "Eight", "One", 3);
			break;
		case 6:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			Question("Question 7:\nHow many times is the bell rung for 0830?", "One", "Four", "Two", "Nine", 1);
			break;
		case 7:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			Question("Question 8:\nHow many times is the bell rung for 0900?", "Three", "Six", "Two", "Five", 3);
			break;
		case 8:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			Question("Question 9:\nHow many times is the bell rung for 0930?", "Five", "One", "Two", "Three", 4);
			break;
		case 9:
			if(lastQuestion < questionNumber){
				
				lastQuestion = questionNumber;
			}
			Question("Question 10:\nHow many times is the bell rung for 1000?", "Eight", "Four", "Two", "Seven", 2);
			break;
		default:
			Finish();
			break;
		}
	}
	//Display a buestion (must be called from OnGUI)
	void Question(string question, string one, string two, string three, string four, int correct){
		GUI.BeginGroup(playArea);
		//Question label
		GUI.Label(new Rect(textNorm), question, style);
		//Score label
		string scoreString = numCorrect + " of " + questionNumber + " correct";
		GUI.Label(new Rect(scoreNorm), scoreString, style);
		bool right = false;
		//Button 1
		if(GUI.Button(new Rect(button1Norm), one)&&!isLocked){
			
			if(correct == 1){
				right = true;
			}
			StartCoroutine("showFeedBack",right);			
		}
		//Button 2
		if(GUI.Button(new Rect(button2Norm), two)&&!isLocked){
			
			if(correct == 2){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Button 3
		if(GUI.Button(new Rect(button3Norm), three)&&!isLocked){
			
			if(correct == 3){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Button 4
		if(GUI.Button(new Rect(button4Norm), four)&&!isLocked){
			
			if(correct == 4){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Quit Button
		if(GUI.Button(new Rect(buttonQuitNorm), "Quit")){
			
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();	
		
	}
	
	//Called when the questions are finished (called from OnGUI)
	void Finish(){
		GUI.BeginGroup(playArea);
		string response;
		
		if(numCorrect < passNumber){
			response = "You answered "+numCorrect+" correct and "+(numberOfQuestions - numCorrect)+"\nincorrect.\n\nYou need "+
				passNumber+ " to pass this station.\nGood luck next time.";
			if(doOnce){
				if(!Player.stationStatus[stationID])
					Player.stationStatus[stationID] = false;
				if(Player.stationScore[stationID] < numCorrect)
					Player.stationScore[stationID] = numCorrect;
			}
		}
		else{
			response = "You answered "+numCorrect+" correct and "+(numberOfQuestions - numCorrect)+"\nincorrect.\n\nYou passed " +
				"this station.\nGood job!!";
			if(doOnce){
				Player.stationStatus[stationID] = true;
				if(Player.stationScore[stationID] < numCorrect)
					Player.stationScore[stationID] = numCorrect;
			}
		}
		if(doOnce){
			doOnce = false;
			//Debug.Log("Finished "+Player.stationStatus[stationID]);
		}
		GUI.Label(new Rect(textNorm), response, style);
		if(GUI.Button(new Rect(button4Norm), "OK")){
			audio.PlayOneShot(beep);
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();
	}
	
	//Called on the answering of a question (displays GUItextures)
	IEnumerator showFeedBack(bool correct){
		isLocked = true;
		if(correct){
			Instantiate(checkmark);
		}
		else{
			Instantiate(xmark);
		}
		yield return new WaitForSeconds(1.5f);
		if(correct)
			numCorrect++;
		questionNumber++;
		isLocked = false;
	}
	
	IEnumerator displayArrow(int question){
		arrowLock = true;
		    //Debug.Log("called");
			if(question == 1)
					Instantiate(arrow1);
			else if(question == 2)
					Instantiate(arrow2);
			else if(question == 3)		
					Instantiate(arrow3);
				
		yield return new WaitForSeconds(0f);
		
	}
	
	
	
}
