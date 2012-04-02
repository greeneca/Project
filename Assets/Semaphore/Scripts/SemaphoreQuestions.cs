using UnityEngine;
using System.Collections;

public class SemaphoreQuestions : MonoBehaviour {

	//station UID
	public readonly int stationID = 3;
	
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
	readonly int numberOfQuestions = 10;
	readonly int passNumber = 7;
	int numCorrect;
	
	//Style for labels
	private GUIStyle style = new GUIStyle();
	
	//Locks
	private bool doOnce;
	private bool isLocked;
	
	//Arms
	private GameObject LeftArm;
	private GameObject RightArm;
	private float LArmAngle;
	private float RArmAngle;
	//private readonly float smooth = 0.01f;
	//private readonly float angleTollerance = 10.0f;
	
		// Use this for initialization
	void Start () {		
		//init locks
		doOnce = true;
		isLocked = false;
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
		//init arms
		LeftArm = GameObject.Find("Left_Arm");
		RightArm = GameObject.Find("Right_Arm");
		LArmAngle = 90.0f;
		RArmAngle = 270.0f;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		//move min arm
		float rot = Mathf.LerpAngle(minArm.transform.eulerAngles.x, minArmAngle, Time.time*smooth);
		Vector3 angle = new Vector3(rot, 110, 0);
		minArm.transform.eulerAngles = angle;
		//moce hour arm
		rot = Mathf.LerpAngle(hourArm.transform.eulerAngles.x, hourArmAngle, Time.time*smooth);
		angle.x = rot;
		hourArm.transform.eulerAngles = angle;
		*/
		
		
		//move min arm
		Vector3 angle = new Vector3(RArmAngle, 110, 0);
		RightArm.transform.eulerAngles = angle;
		//moce hour arm
		angle.x = LArmAngle;
		LeftArm.transform.eulerAngles = angle;
		
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0://---------------------------------------------------Need AM/PM
			if(lastQuestion < questionNumber){
				SetArms(13, 30);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the displayed time in the\n24-hour clock?", "1230h", "1330h", "1300h", "1100h", 2);
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
			audio.Stop();
			audio.PlayOneShot(beep);
			if(correct == 1){
				right = true;
			}
			StartCoroutine("showFeedBack",right);			
		}
		//Button 2
		if(GUI.Button(new Rect(button2Norm), two)&&!isLocked){
			audio.Stop();
			audio.PlayOneShot(beep);
			if(correct == 2){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Button 3
		if(GUI.Button(new Rect(button3Norm), three)&&!isLocked){
			audio.Stop();
			audio.PlayOneShot(beep);
			if(correct == 3){
				right = true;
			}
			StartCoroutine("showFeedBack",right);
		}
		//Button 4
		if(GUI.Button(new Rect(button4Norm), four)&&!isLocked){
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
	
	//Called at the beginnig of a new question to play a call.
	void SetArms(int Left, int Right){
		//TODO set arms location
	}
}
