using UnityEngine;
using System.Collections;

public class mainGUIScript : MonoBehaviour {
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect AchievementsList;
	public Rect Play;
	public Rect Achievements;
	public Rect Instructions;
	public Rect Quit;
	//private Rect achListNorm;
	private Rect playNorm;
	private Rect achNorm;
	private Rect instNorm;
	//private Rect quitNorm;
	private Rect playArea;
	
	static bool menuLoaded = false;
	
	// Use this for initialization
	void Start () {
		playArea = new Rect(0, 0, Screen.width, Screen.height);
		//achListNorm = new Rect(AchievementsList.x * playArea.width, AchievementsList.y * playArea.height, AchievementsList.width * playArea.width, AchievementsList.height * playArea.height);
		playNorm = new Rect(Play.x * playArea.width, Play.y * playArea.height, Play.width * playArea.width, Play.height * playArea.height);	
		achNorm = new Rect(Achievements.x * playArea.width, Achievements.y * playArea.height, Achievements.width * playArea.width, Achievements.height * playArea.height);
		instNorm = new Rect(Instructions.x * playArea.width, Instructions.y * playArea.height, Instructions.width * playArea.width, Instructions.height * playArea.height);
		//quitNorm = new Rect(Quit.x * playArea.width, Quit.y * playArea.height, Quit.width * playArea.width, Quit.height * playArea.height);
		if(menuLoaded){
			Player.resetPosition();
		}		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.skin = menuSkin; 
		GUI.BeginGroup(playArea);
		if(GUI.Button(new Rect(playNorm), "Play")){
			audio.PlayOneShot(beep);
			menuLoaded = true;
			Application.LoadLevel("Menu");
		}
		if(GUI.Button(new Rect(instNorm), "Instructions")){
			audio.PlayOneShot(beep);
			Application.LoadLevel("Instructions");
		}
		//if(GUI.Button(new Rect(achNorm), "Achievements")){
		//	audio.PlayOneShot(beep);
		//	Application.LoadLevel("Achievements");
		//}
		
		//Do Not Need Quit for Web Deployment
		
		//if(GUI.Button(new Rect(quitNorm), "Quit")){
		//if(GUI.Button(new Rect(achNorm), "Quit")){
		//	audio.PlayOneShot(beep);
		//	Application.Quit();
		//}
		GUI.EndGroup();
	}
}
