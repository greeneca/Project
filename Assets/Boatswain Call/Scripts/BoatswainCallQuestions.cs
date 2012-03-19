using UnityEngine;
using System.Collections;

public class BoatswainCallQuestions : MonoBehaviour {
	
	//GUI Stuff
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect text;
	public Rect button1;
	public Rect button2;
	public Rect button3;
	public Rect button4;
	private Rect textNorm;
	private Rect button1Norm;
	private Rect button2Norm;
	private Rect button3Norm;
	private Rect button4Norm;
	private Rect playArea;
	
	//Question state
	int questionNumber;
	readonly int numberOfQuestions = 2;
	bool[] questions;
	int numCorrect;
	
	//Bosn Calls
	public AudioClip still;
	public AudioClip general;
	public AudioClip side;
	public AudioClip carryon;
	private GameObject boatswainCall;
	private bool clipPlayed;
	
	// Use this for initialization
	void Start () {
		clipPlayed = false;
		boatswainCall = GameObject.Find("Bosn Call");
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		questionNumber = 0;
		questions = new bool[numberOfQuestions];
		for(int i = 0; i < numberOfQuestions; i++){
			questions[i] = true;
		}
		numCorrect = 0;
		textNorm = new Rect(text.x * playArea.width, text.y * playArea.height, text.width * playArea.width, text.height * playArea.height);
		button1Norm = new Rect(button1.x * playArea.width, button1.y * playArea.height, button1.width * playArea.width, button1.height * playArea.height);
		button2Norm = new Rect(button2.x * playArea.width, button2.y * playArea.height, button2.width * playArea.width, button2.height * playArea.height);
		button3Norm = new Rect(button3.x * playArea.width, button3.y * playArea.height, button3.width * playArea.width, button3.height * playArea.height);
		button4Norm = new Rect(button4.x * playArea.width, button4.y * playArea.height, button4.width * playArea.width, button4.height * playArea.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0:
			Question("Question 1:\nWhat is the following call?", "The Still", "The Side", "The Carry On", "The General Call", 2);
			if(!clipPlayed){
				StartCoroutine("PlayClipSide");
				clipPlayed = true;
			}
			break;
		case 1:
			Question("Question 2:\nWhat is the following call?", "The Still", "The Side", "The Carry On", "The General Call", 4);
			if(!clipPlayed){
				StartCoroutine("PlayClipGeneral");
				clipPlayed = true;
			}
			break;
		case 2:
			Question("Question 3:\nWhat is the following call?", "The Still", "The Side", "The Carry On", "The General Call", 1);
			if(!clipPlayed){
				StartCoroutine("PlayClipStill");
				clipPlayed = true;
			}
			break;
		case 3:
			Question("Question 4:\nWhat is the following call?", "The Still", "The Side", "The Carry On", "The General Call", 3);
			if(!clipPlayed){
				StartCoroutine("PlayClipCarryOn");
				clipPlayed = true;
			}
			break;
		default:
			Finish();
			break;
		}
	}
	
	void Question(string question, string one, string two, string three, string four, int correct){
		GUI.BeginGroup(playArea);
		GUI.Label(new Rect(textNorm), question);
		if(GUI.Button(new Rect(button1Norm), one)){
			if(correct == 1){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
			clipPlayed = false;
		}
		if(GUI.Button(new Rect(button2Norm), two)){
			if(correct == 2){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
			clipPlayed = false;
		}
		if(GUI.Button(new Rect(button3Norm), three)){
			if(correct == 3){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
			clipPlayed = false;
		}
		if(GUI.Button(new Rect(button4Norm), four)){
			if(correct == 4){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
			clipPlayed = false;
		}
		GUI.EndGroup();	
		
	}
	
	void Finish(){
		GUI.BeginGroup(playArea);
		GUI.Label(new Rect(textNorm), "Put Stuff Here");
		if(GUI.Button(new Rect(button4Norm), "OK")){
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();
	}
	
	IEnumerator PlayClipSide(){
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(side);
	}
	IEnumerator PlayClipGeneral(){
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(general);
	}
	IEnumerator PlayClipStill(){
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(still);
	}
	IEnumerator PlayClipCarryOn(){
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(carryon);
	}
	
}
