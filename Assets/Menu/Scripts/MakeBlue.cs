using UnityEngine;
using System.Collections;

public class MakeBlue : MonoBehaviour {
	
	public GUITexture WaterGui;

	// Use this for initialization
	void Start () {
		WaterGui.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter () {
		if(!WaterGui.enabled)
			WaterGui.enabled = true;
	}
	
	void OnTriggerExit () {
		if(WaterGui.enabled)
			WaterGui.enabled = false;
	}
}
