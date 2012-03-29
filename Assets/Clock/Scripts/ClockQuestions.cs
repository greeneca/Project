using UnityEngine;
using System.Collections;

public class ClockQuestions : MonoBehaviour {

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
	private GameObject minArm;
	private GameObject hourArm;
	private float minArmAngle;
	private float hourArmAngle;
	private readonly float smooth = 0.1f;
	private readonly float angleTollerance = 10.0f;
	
	//plate
	public Texture2D am;
	public Texture2D pm;
	public Texture2D blank;
	private GameObject APMplate;
		
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
		minArm = GameObject.Find("ClockArmMin");
		hourArm = GameObject.Find("ClockArmHour");
		APMplate = GameObject.Find("APMplate");
		minArmAngle = 90.0f;
		hourArmAngle = 270.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//move min arm
		Vector3 angle = new Vector3(minArmAngle, 110, 0);
		minArm.transform.eulerAngles = angle;
		//moce hour arm
		angle.x = hourArmAngle;
		hourArm.transform.eulerAngles = angle;
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0://---------------------------------------------------Need AM/PM
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(13, 30));
				APMplate.renderer.material.SetTexture("_MainTex", pm);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the displayed time in the\n24-hour clock?", "1230h", "1330h", "1300h", "1100h", 2);
			break;
		case 1:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(20, 55));
				APMplate.renderer.material.SetTexture("_MainTex", pm);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the displayed time in the\n24-hour clock?", "0855h", "2035h", "0825h", "2055h", 4);
			break;
		case 2:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(1, 20));
				APMplate.renderer.material.SetTexture("_MainTex", am);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the displayed time in the\n24-hour clock?", "0140h", "1320h", "0120h", "1200h", 3);
			break;
		case 3:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(6, 45));
				APMplate.renderer.material.SetTexture("_MainTex", am);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the displayed time in the\n24-hour clock?", "0645h", "1845h", "1940h", "0700h", 1);
			break;
		case 4:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(18, 15));
				APMplate.renderer.material.SetTexture("_MainTex", pm);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the displayed time in the\n24-hour clock?", "0515h", "0615h", "0710h", "1815h", 4);
			break;
		case 5://----------------------------------------------------Do more for these questions?
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(12, 60));//3:25pm
				APMplate.renderer.material.SetTexture("_MainTex", blank);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is 1525h in the\n12-hour clock?", "3:25 pm", "1:25 pm", "3:25 am", "1:25 am", 1);
			break;
		case 6:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(12, 60));//9:20pm
				APMplate.renderer.material.SetTexture("_MainTex", blank);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is 2120h in the\n12-hour clock?", "11:20 am", "9:20 pm", "9:20 am", "11:20 pm", 2);
			break;
		case 7:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(12, 60));//8:55am
				APMplate.renderer.material.SetTexture("_MainTex", blank);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is 0855h in the\n12-hour clock?", "8:55 pm", "9:45 pm", "8:55 am", "7:55 am", 3);
			break;
		case 8:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(12, 60));//2:00pm
				APMplate.renderer.material.SetTexture("_MainTex", blank);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is 1400h in the\n12-hour clock?", "2:00 pm", "1:00 pm", "3:00 am", "1:00 am", 1);
			break;
		case 9:
			if(lastQuestion < questionNumber){
				StartCoroutine(SetArms(12, 60));//6:40pm
				APMplate.renderer.material.SetTexture("_MainTex", blank);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is 1840h in the\n12-hour clock?", "7:40 am", "7:40 pm", "6:40 am", "6:40 pm", 4);
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
	IEnumerator SetArms(int hour, int min){
		//TODO set arms location
		float angle = ((((hour%12)-9)*-1));
		if(angle < 0)
			angle = 12+angle;
		angle *=30;
		//set hour angle
		hourArmAngle = angle;
		
		angle = ((((min/5)-9)*-1));
		if(angle < 0)
			angle = 12+angle;
		angle *=30;
		//set minute angle
		minArmAngle = angle;
		yield return new WaitForSeconds(0.01f);
	}
}
