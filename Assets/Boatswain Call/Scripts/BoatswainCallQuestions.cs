using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class BoatswainCallQuestions : MonoBehaviour {
	
	//station UID
	public readonly int stationID = 1;
	
	//Feedback
	public GUITexture checkmark;
	public GUITexture xmark;
	
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
	readonly int numberOfQuestions = 8;
	readonly int passNumber = 5;
	int numCorrect;
	
	//Bosn Calls
	public AudioClip still;
	public AudioClip general;
	public AudioClip side;
	public AudioClip carryon;
	
	//public GameObject pipe;
	
	//Style for labels
	private GUIStyle style = new GUIStyle();
	
	
	// Use this for initialization
	void Start () {		
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
		style.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0:
			//General Call
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClip", general);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nName the following call?", "The Still", "The Side", "The Carry On", "The General Call", 4);
			break;
		case 1:
			Question("Question 2:\nWhat is the proper response upon\n\thearing the general call?\n\nA - Stop what you are doing " +
			 	"and\n\tlisten for orders.\nB - Adopt the position of attention and\n\tlisten for instructions.\nC - Continue with " +
			 	"given orders or\n\tinstructions.\nD - Preform the proper forms of\n\trespect to the diginatires.", "A", "B", "C", "D", 1);
			break;
		case 2:
			//The Still
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClip", still);
				lastQuestion = questionNumber;
			}
			Question("Question 3:\nName the following call?", "The Still", "The Side", "The Carry On", "The General Call", 1);
			break;
		case 3:
			Question("Question 4:\nWhat is the proper response upon\n\thearing the general call?\n\nA - Stop what you are doing " +
			 	"and\n\tlisten for orders.\nB - Adopt the position of attention and\n\tlisten for instructions.\nC - Continue with " +
			 	"given orders or\n\tinstructions.\nD - Preform the proper forms of\n\trespect to the diginatires.", "A", "B", "C", "D", 2);
			break;
		case 4:
			// The Carry On
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClip", carryon);
				lastQuestion = questionNumber;
			}
			Question("Question 5:\nName the following call?", "The Still", "The Side", "The Carry On", "The General Call", 3);
			break;
		case 5:
			Question("Question 6:\nWhat is the proper response upon\n\thearing the general call?\n\nA - Stop what you are doing " +
			 	"and\n\tlisten for orders.\nB - Adopt the position of attention and\n\tlisten for instructions.\nC - Continue with " +
			 	"given orders or\n\tinstructions.\nD - Preform the proper forms of\n\trespect to the diginatires.", "A", "B", "C", "D", 3);
			break;
		case 6:
			// The Side
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClip", side);
				lastQuestion = questionNumber;
			}
			Question("Question 7 (BONUS):\nWName the following call?", "The Still", "The Side", "The Carry On", "The General Call", 2);
			break;
		case 7:
			Question("Question 6 (BONUS):\nWhat is the proper response upon\n\thearing the general call?\n\nA - Stop what you are doing " +
			 	"and\n\tlisten for orders.\nB - Adopt the position of attention and\n\tlisten for instructions.\nC - Continue with " +
			 	"given orders or\n\tinstructions.\nD - Preform the proper forms of\n\trespect to the diginatires.", "A", "B", "C", "D", 4);
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
		if(GUI.Button(new Rect(button1Norm), one)){
			audio.Stop();
			audio.PlayOneShot(beep);
			if(correct == 1){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
			
		}
		//Button 2
		if(GUI.Button(new Rect(button2Norm), two)){
			audio.Stop();
			audio.PlayOneShot(beep);
			if(correct == 2){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Button 3
		if(GUI.Button(new Rect(button3Norm), three)){
			audio.Stop();
			audio.PlayOneShot(beep);
			if(correct == 3){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Button 4
		if(GUI.Button(new Rect(button4Norm), four)){
			audio.Stop();
			audio.PlayOneShot(beep);
			if(correct == 4){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Quit Button
		if(GUI.Button(new Rect(buttonQuitNorm), "Quit")){
			audio.Stop();
			audio.PlayOneShot(beep);
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();	
		
	}
	
	//Called when the questions are finished (called from OnGUI)
	void Finish(){
		GUI.BeginGroup(playArea);
		string response;
		if(numCorrect < passNumber){
			response = "You answered "+numCorrect+" correct and "+(numberOfQuestions - numCorrect)+" incorrect.\n\nYou need "+
				passNumber+ " to pass this station. Good luck next time.";
			Player.stationStatus[stationID] = false;
			Player.stationScore[stationID] = numCorrect;
		}
		else{
			response = "You answered "+numCorrect+" correct and "+(numberOfQuestions - numCorrect)+" incorrect.\n\nYou passed " +
				"this station. Good job!!";
			Player.stationStatus[stationID] = true;
			Player.stationScore[stationID] = numCorrect;
		}
		GUI.Label(new Rect(textNorm), response);
		if(GUI.Button(new Rect(button4Norm), "OK")){
			audio.PlayOneShot(beep);
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();
	}
	
	//Called on the answering of a question (displays GUItextures)
	IEnumerator showFeedBack(bool correct){
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
	}
	
	//Called at the beginnig of a new question to play a call.
	IEnumerator PlayClip(AudioClip clip){
		yield return new WaitForSeconds(0.2f);
		audio.PlayOneShot(clip);
	}
}
