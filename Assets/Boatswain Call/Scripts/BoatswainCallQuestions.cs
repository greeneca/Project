using UnityEngine;
using System.Collections;

public class BoatswainCallQuestions : MonoBehaviour {
	
	public GUITexture checkmark;
	
	//GUI Stuff
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect text;
	public Rect button1;
	public Rect button2;
	public Rect button3;
	public Rect button4;
	public Rect buttonQuit;
	private Rect textNorm;
	private Rect button1Norm;
	private Rect button2Norm;
	private Rect button3Norm;
	private Rect button4Norm;
	private Rect buttonQuitNorm;
	private Rect playArea;
	
	//Question state
	int questionNumber;
	int lastQuestion;
	readonly int numberOfQuestions = 4;
	bool[] questions;
	int numCorrect;
	
	//Bosn Calls
	public AudioClip still;
	public AudioClip general;
	public AudioClip side;
	public AudioClip carryon;
	private GameObject boatswainCall;
	
	// Use this for initialization
	void Start () {
		boatswainCall = GameObject.Find("Bosn Call");
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		questionNumber = 0;
		lastQuestion = -1;
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
		buttonQuitNorm = new Rect(buttonQuit.x * playArea.width, buttonQuit.y * playArea.height, buttonQuit.width * playArea.width, buttonQuit.height * playArea.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0:
			Debug.Log("Showing Question 1");
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClipSide");
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the following call?(Side)", "The Still", "The Side", "The Carry On", "The General Call", 2);
			break;
		case 1:
			Debug.Log("Showing Question 2");
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClipGeneral");
				lastQuestion = questionNumber;
			}
			Question("Question 2:\nWhat is the following call?(Gen)", "The Still", "The Side", "The Carry On", "The General Call", 4);
			break;
		case 2:
			Debug.Log("Showing Question 3");
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClipStill");
				lastQuestion = questionNumber;
			}
			Question("Question 3:\nWhat is the following call?(Still)", "The Still", "The Side", "The Carry On", "The General Call", 1);
			break;
		case 3:
			Debug.Log("Showing Question 4");
			if(lastQuestion < questionNumber){
				StartCoroutine("PlayClipCarryOn");
				lastQuestion = questionNumber;
			}
			Question("Question 4:\nWhat is the following call?(Carry)", "The Still", "The Side", "The Carry On", "The General Call", 3);
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
			audio.PlayOneShot(beep);
			if(correct == 1){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		if(GUI.Button(new Rect(button2Norm), two)){
			audio.PlayOneShot(beep);
			if(correct == 2){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		if(GUI.Button(new Rect(button3Norm), three)){
			audio.PlayOneShot(beep);
			if(correct == 3){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		if(GUI.Button(new Rect(button4Norm), four)){
			audio.PlayOneShot(beep);
			if(correct == 4){
				questions[questionNumber] = true;
				numCorrect++;
			}
			else
				questions[questionNumber] = false;
			questionNumber++;
		}
		if(GUI.Button(new Rect(buttonQuitNorm), "Quit")){
			audio.PlayOneShot(beep);
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();	
		
	}
	
	void Finish(){
		GUI.BeginGroup(playArea);
		GUI.Label(new Rect(textNorm), "You got "+numCorrect+" correct and "+(numberOfQuestions - numCorrect)+" wrong.");
		if(GUI.Button(new Rect(button4Norm), "OK")){
			audio.PlayOneShot(beep);
			Application.LoadLevel("Menu");
		}
		GUI.EndGroup();
	}
	
	IEnumerator PlayClipSide(){
		Debug.Log("Playing Side");
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(side);
	}
	IEnumerator PlayClipGeneral(){
		Debug.Log("Playing gen");
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(general);
	}
	IEnumerator PlayClipStill(){
		Debug.Log("Playing still");
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(still);
	}
	IEnumerator PlayClipCarryOn(){
		Debug.Log("Playing carryon");
		yield return new WaitForSeconds(0.5f);
		boatswainCall.audio.PlayOneShot(carryon);
	}
	
}
