using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour {
	
	public GUIText theText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SetText(string text){
		theText.text = text;
	}
	
	void DestroyMe(){
		Destroy(gameObject);
	}
}
