using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void setText(string newText){
		gameObject.guiText.text = newText;
	}
}
