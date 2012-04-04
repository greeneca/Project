using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class GUIScript : MonoBehaviour {
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect text;
	public Rect score;
	public Rect buttonQuit;
	private Rect textNorm;
	private Rect scoreNorm;
	private Rect buttonQuitNorm;
	private Rect playArea;
	//Style for labels
	private GUIStyle style = new GUIStyle();
	//Station Text
	public static bool showText;
	public static string stationText;
	
	// Use this for initialization
	void Start () {
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		textNorm = new Rect(text.x * playArea.width, text.y * playArea.height, text.width * playArea.width, text.height * playArea.height);
		scoreNorm = new Rect(score.x * playArea.width, score.y * playArea.height, score.width * playArea.width, score.height * playArea.height);
		buttonQuitNorm = new Rect(buttonQuit.x * playArea.width, buttonQuit.y * playArea.height, buttonQuit.width * playArea.width, buttonQuit.height * playArea.height);
		//init style
		style.fontSize = 18;
		style.normal.textColor = Color.blue;
		//init station text
		showText = false;
		stationText = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		string scoreText = Player.stationsComplete()+"/"+Player.stations+" Complete";
		GUI.skin = menuSkin; 
		GUI.BeginGroup(playArea);
		//Station Text
		if(showText)
		GUI.TextArea(new Rect(textNorm), stationText);//, style);
		//Games Score
		GUI.TextArea(new Rect(scoreNorm), scoreText);//, style);
		//Quit Button
		if(GUI.Button(new Rect(buttonQuitNorm), "Quit")){
			audio.Stop();
			audio.PlayOneShot(beep);
			Application.LoadLevel("MainMenu");
		}
		GUI.EndGroup();	
	}
	
}
