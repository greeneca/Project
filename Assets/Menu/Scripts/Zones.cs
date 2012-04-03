using UnityEngine;
using System.Collections;

public class Zones : MonoBehaviour {
	
	public int stationID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(){
		Player.setGUITextFor(stationID);
	}
	
	void OnTriggerExit(){
		Player.resetGUIText();
	}
}
