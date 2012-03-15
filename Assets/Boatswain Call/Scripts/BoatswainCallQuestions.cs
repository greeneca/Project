using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class BoatswainCallQuestions : MonoBehaviour {
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect text;
	public Rect button1;
	public Rect button2;
	public Rect button3;
	public Rect button4;
	Rect playArea;
	
	// Use this for initialization
	void Start () {
		playArea = Rect(0, 0, Screen.width, Screen.height);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
 		GUI.skin = menuSkin; 
	}
	
	void Question(string question, string one, string two, string three, string four){
		GUI.BeginGroup();
		GUI.Label(new Rect(text), question);
		if(GUI.Button(new Rect(button1), one)){
		}
		if(GUI.Button(new Rect(button2), two)){
		}
		if(GUI.Button(new Rect(button3), three)){
		}
		if(GUI.Button(new Rect(button4), four)){
		}
		GUI.EndGroup();
	}
