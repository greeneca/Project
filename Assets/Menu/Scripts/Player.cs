using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//Position
	static Vector3 position = new Vector3(0, 0, 0);
	static Quaternion rotation = new Quaternion(0, 0, 0, 0);
	
	//Stations
	public static readonly int stations = 6;
	public static bool[] stationStatus = null;
	public static int[] stationScore = null;
	public static int[] stationAttempts = null;
	private static readonly string[] stationNames = {"Naval Terminology", "Boatswains Call", "Ship's Bell", "24-Hour Clock",
		"Semaphore Flags", "Signal Flags"};
	private static readonly string[] stationDescription = {"Match naval terms with common terms.",
													"Identify calls and their uses.",
													"Identify parts of a bell and the\nprocess of ringing a ship's bell.",
													"Convert times between the 24-hour\nclock and the 12-hour clock.",
													"Identify semaphore flag signals.",
													"Identify siganl flags."};
	
	//Achievements
	public static readonly int achievementNum = 8;
	public static bool[] achievements = null;
	public static bool[] notifiedAchievements = null;	
	private static readonly string[] achievementName = {"Knows Terminology",
														"Knows the Pipes",
														"Knows the Bells",
														"Knows the Time",
														"Knows Semaphore",
														"Knows the Flags",
														"Knows Something",
														"11th Times the Charm"};
	
	public GameObject achievePrefab;
	
	// Use this for initialization
	void Start () {	
		//reset position
		if(position.x != 0 && position.y != 0 && position.z != 0){
			transform.position = position;
			transform.rotation = rotation;
			transform.Translate(Vector3.up*2);
			transform.Translate(Vector3.back*10);
			//Debug.Log(position);
		}		
		if(stationScore == null || stationStatus == null || stationAttempts == null || 
				achievements == null || notifiedAchievements == null){
			//initialize stations
			stationStatus = new bool[stations];
			stationScore = new int[stations];
			stationAttempts = new int[stations];
			achievements = new bool[achievementNum];
			notifiedAchievements = new bool[achievementNum];
			for(int i = 0; i < stations; i++){
				stationStatus[i] = false;
				stationScore[i] = 0;
				stationAttempts[i] = 0;
			}
			for(int i = 0; i < achievementNum; i++){
				achievements[i] = false;
				notifiedAchievements[i] = false;
		}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//update postion
		position.x = transform.position.x;
		position.y = transform.position.y;
		position.z = transform.position.z;
		//update rotation
		rotation.x = transform.rotation.x;
		rotation.y = transform.rotation.y;
		rotation.z = transform.rotation.z;
		rotation.w = transform.rotation.w;
		
		//Test stations
		for(int i = 0; i < stations; i++){
			if(stationStatus[i])
				achievements[i] = true;
		}
		
		if(!achievements[6]){//Test for a station finished
			for(int i = 0; i < stations; i++){
				if(stationStatus[i]){
					//achievements[6] = true;
					break;
				}
			}
		}
		if(!achievements[7]){//Test for 10 station attemps
			int count = 0;
			for(int i = 0; i < stations; i++){
				count += stationAttempts[i];
			}
			//if(count >= 10)
				//achievements[7] = true;
		}
		
		//check notification
		StartCoroutine("notifications");
	}
	
	public static int stationsComplete(){
		int complete = 0;
		for(int i = 0; i < stations; i++){
			//Debug.Log(i+" - "+stationStatus[i]);
			if(stationStatus[i])
				complete++;
		}
		return complete;
	}	
	public static void setGUITextFor(int id){
		GUIScript.stationText = stationNames[id]+":\n\n"+stationDescription[id]+"\n\nComplete: "+stationStatus[id]
			+"\nAttempts: "+stationAttempts[id]+"\nScore: "+stationScore[id];
		GUIScript.showText = true;
	}
	public static void resetGUIText(){
		GUIScript.showText = false;
	}
	public static void resetPosition(){
		position = new Vector3(0, 0, 0);
		rotation = new Quaternion(0, 0, 0, 0);
	}
	
	IEnumerator notifications(){
		for(int i = 0; i < achievementNum; i++){
			if(achievements[i] && !notifiedAchievements[i]){
				notifiedAchievements[i] = true;
				Instantiate(achievePrefab);
				GameObject.Find("Text").SendMessage("setText", achievementName[i]);
				yield return new WaitForSeconds(20.0f);
			}
		}
	}
}
