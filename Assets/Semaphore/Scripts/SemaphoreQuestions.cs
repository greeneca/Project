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
	private float LArmAngleX;
	private float RArmAngleX;
	private float LArmAngleY;
	private float RArmAngleY;
	private float LArmAngleZ;
	private float RArmAngleZ;
	//private readonly float smooth = 0.01f;
	//private readonly float angleTollerance = 10.0f;
	
		// Use this for initialization
	void Start () {	
		Player.stationAttempts[stationID]++;	
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
		LArmAngleX = -0.0f;
		LArmAngleY = 90.0f;
		LArmAngleZ = 0.0f;
		
		RArmAngleX = -45.0f;
		RArmAngleY = 90.0f;
		RArmAngleZ = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//move min arm
		RightArm.transform.eulerAngles = new Vector3(RArmAngleX, RArmAngleY, RArmAngleZ);
		//move hour arm
		LeftArm.transform.eulerAngles = new Vector3(LArmAngleX, LArmAngleY, LArmAngleZ);
		
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
		switch(questionNumber){
		case 0:
			if(lastQuestion < questionNumber){
				SetArms(4, 3);
				lastQuestion = questionNumber;
			}
			Question("Question 1:\nWhat is the displayed character?", "A", "G", "M", "W", 2);
			break;
		case 1:
			if(lastQuestion < questionNumber){
				SetArms(2, 4);
				lastQuestion = questionNumber;
			}
			Question("Question 2:\nWhat is the displayed character?", "H", "S", "U", "B", 4);
			break;
		case 2:
			if(lastQuestion < questionNumber){
				SetArms(1, 0);
				lastQuestion = questionNumber;
			}
			Question("Question 3:\nWhat is the displayed character?", "Z", "P", "L", "T", 4);
			break;
		case 3:
			if(lastQuestion < questionNumber){
				SetArms(2, 1);
				lastQuestion = questionNumber;
			}
			Question("Question 4:\nWhat is the displayed character?", "E", "W", "Q", "L", 3);
			break;
		case 4:
			if(lastQuestion < questionNumber){
				SetArms(3, 3);
				lastQuestion = questionNumber;
			}
			Question("Question 5:\nWhat is the displayed character?", "A", "N", "F", "P", 2);
			break;
		case 5:
			if(lastQuestion < questionNumber){
				SetArms(2, 0);
				lastQuestion = questionNumber;
			}
			Question("Question 6:\nWhat is the displayed character?", "E", "P", "W", "K", 2);
			break;
		case 6:
			if(lastQuestion < questionNumber){
				SetArms(2, 3);
				lastQuestion = questionNumber;
			}
			Question("Question 7:\nWhat is the displayed character?", "Q", "Y", "D", "S", 4);
			break;
		case 7:
			if(lastQuestion < questionNumber){
				SetArms(2, 2);
				lastQuestion = questionNumber;
			}
			Question("Question 8:\nWhat is the displayed character?", "R", "Y", "E", "M", 1);
			break;
		case 8:
			if(lastQuestion < questionNumber){
				SetArms(1, 2);
				lastQuestion = questionNumber;
			}
			Question("Question 9:\nWhat is the displayed character?", "B", "A", "Y", "U", 3);
			break;
		case 9:
			if(lastQuestion < questionNumber){
				SetArms(1, 4);
				lastQuestion = questionNumber;
			}
			Question("Question 10:\nWhat is the displayed character?", "X", "Z", "C", "N", 3);
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
		switch(Left){
		case 0:
			LArmAngleX = -180.0f;
			break;
		case 1:
			LArmAngleX = -135.0f;
			break;
		case 2:
			LArmAngleX = -90.0f;
			break;
		case 3:
			LArmAngleX = -45.0f;
			break;
		case 4:
			LArmAngleX = 0.0f;
			break;
		default:
			LArmAngleX = 0;
			break;
		}
		switch(Right){
		case 0:
			RArmAngleX = 0.0f;
			break;
		case 1:
			RArmAngleX = -45.0f;
			break;
		case 2:
			RArmAngleX = -90.0f;
			break;
		case 3:
			RArmAngleX = -135.0f;
			break;
		case 4:
			RArmAngleX = -180.0f;
			break;
		default:
			RArmAngleX = 0;
			break;
		}
	}
}
