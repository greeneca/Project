using UnityEngine;
using System.Collections;

public class InstructionsGUI : MonoBehaviour {
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect Back;
	private Rect backNorm;
	public Rect Inst;
	private Rect instNorm;
	private Rect playArea;
	
	// Use this for initialization
	void Start () {
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		backNorm = new Rect(Back.x * playArea.width, Back.y * playArea.height, Back.width * playArea.width, Back.height * playArea.height);
		instNorm = new Rect(Inst.x * playArea.width, Inst.y * playArea.height, Inst.width * playArea.width, Inst.height * playArea.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.skin = menuSkin; 
		GUI.BeginGroup(playArea);
		GUI.TextArea(new Rect(instNorm), "To Escape the island you must\ncomplete all of the challenges\nscattered around the island. To\ncomplete" +
			"these challenges you\nwill need to use the knowledge\nyou learned in Phase 1.");
		if(GUI.Button(new Rect(backNorm), "Back")){
			audio.PlayOneShot(beep);
			Application.LoadLevel("MainMenu");
		}
		GUI.EndGroup();
	}
}
