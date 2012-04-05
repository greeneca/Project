using UnityEngine;
using System.Collections;
using System;
public class terminologyQuestions : MonoBehaviour {

	//station UID
	public readonly int stationID = 0;
	
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
	private String answerText = "";
	//Question state
	int questionNumber;
	int lastQuestion;
	readonly int numberOfQuestions = 15;
	readonly int passNumber = 11;
	int numCorrect;
	int numbWrong;
	
	//Style for labels
	private GUIStyle style = new GUIStyle();
	
	//Locks
	private bool doOnce;
	private bool isLocked;
	
	private String[] terms = {"Gash", "Stand Easy", "Secure", "Head", "Duty Watch", "Out Pipes", "Scran Locker", "Pipe", "Colours", "Liberty Boat", "Bulkhead", "Deckhead", "Deck", "Ship's Company", "Sunset", "Gangway", "Galley", "Boatswain's Stores", "Pipe Down", "Kye", "Coxswain", "Belay", "Aye Aye, Sir/Ma'am", "Port", "Starboard", "Ship's Office", "Brow", "Ship's Log", "Quartermaster"};
	private String[] questions = {"Garbage", "A break", "To close up, put away gear", "Toilet", "A division that is selected on a \nrotational basis that is responsible for \ncorps preparation and cleanup", "The commencement of classes or \nthe end of stand easy", "Lost and found", "Sound produced from a \nboatswain's call", "The ceremony of hoisting \nnational colours", 
		                          "When all personnel are dismissed \nfor the day and may go ashore", "A wall", "The ceiling of a ship", "A floor", "The complemnet of a ship", "The ceremony of lowering national \ncolours at the end of the training day", "Any recognized entrance, passageway, \nor traffic route within a ship", "The ships's kitchen", "A storeroom for cleaning gear", 
								  "An order meaning to keep quiet", "A hot drink or snack", "The senior petty officer on a ship/most \nsenior cadet position", "To make fast a rope, or \nto cancel an order", "Order understood and will obey", "Left side of the ship", "Right side of the ship", "Administration office", "Entrance/Exit of ship where personnel \nmust salute as they pass",
								  "A logbook that keeps track of \nthe ship's routine", "At sea, is the master seaman, leading \nseaman or able seaman who is the helmsman. \nIn harbour, is the senior member \nof the gangway staff and is responsible \nfor supervising the boatswain’s mate and \nthe security of the brow. At a corps, is usually \nresponsible for greeting guests and \nfilling in the logbook."};
	private String[] answers = {"", "", "", ""};
	static System.Random r = new System.Random();
	int whichQuestion = 0;
	private int correctAnswer = -1;
	private Rect answerNorm;
	public Rect answer;
	void buildQuestion()
	{
		for (int b = 0; b <= 3; b++)
		{
			answers[b] = "";
		}
		
		int n = r.Next() % 29;
        whichQuestion = n;
		
		Debug.Log(terms[n] + " " + questions[n]);
		int x = r.Next() % 4;
		answers[x] = terms[n];
		correctAnswer = x;
		Debug.Log(correctAnswer);
		
	    for (int i = 0; i <= 3; i++)
		{
			
			int k = r.Next() % 29;
//			Debug.Log(i);
			if(answers[i].Equals(""))
			{
				answers[i] = terms[k];
				while((i != 0 && answers[i].Equals(answers[0])) || (i != 1 && answers[i].Equals(answers[1])) || (i != 2 && answers[i].Equals(answers[2])) || (i != 3 && answers[i].Equals(answers[3])))
				{
					k = r.Next() % 29;
					answers[i] = terms[k];
					
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
		answerNorm = new Rect(answer.x * playArea.width, answer.y * playArea.height, answer.width * playArea.width, answer.height * playArea.height);
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
		if(questionNumber < numberOfQuestions)	{
			if(lastQuestion < questionNumber){
				buildQuestion();
				lastQuestion = questionNumber;
			}
			
			Question("What is the term for: "+questions[whichQuestion], answers[0], answers[1], answers[2], answers[3], correctAnswer);
			GUI.Label(new Rect(answerNorm), "Number correct: " + numCorrect + "\nNumber Wrong: " + numbWrong + "\nAnswer to last question: " + answerText, style);
			
		}
		else {
			
			Finish();
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
			audio.PlayOneShot(beep);
			if(correct == 0){
				
				right = true;
				
			}
			else
				numbWrong++;
			StartCoroutine("showFeedBack",right);			
		}
		//Button 2
		if(GUI.Button(new Rect(button2Norm), two)&&!isLocked){
			audio.PlayOneShot(beep);
			if(correct == 1){
		
				right = true;
			}
			else
				numbWrong++;
			StartCoroutine("showFeedBack",right);
		}
		//Button 3
		if(GUI.Button(new Rect(button3Norm), three)&&!isLocked){
			audio.PlayOneShot(beep);
			if(correct == 2){
			
				right = true;
			}
			else
				numbWrong++;
			StartCoroutine("showFeedBack",right);
		}
		//Button 4
		if(GUI.Button(new Rect(button4Norm), four)&&!isLocked){
			audio.PlayOneShot(beep);
			if(correct == 3){
				
				right = true;
			}
			else
				numbWrong++;
			StartCoroutine("showFeedBack",right);
		}
		//Quit Button
		if(GUI.Button(new Rect(buttonQuitNorm), "Quit")){
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
	
	
}
