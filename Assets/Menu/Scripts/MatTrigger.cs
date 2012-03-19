using UnityEngine;
using System.Collections;

public class MatTrigger : MonoBehaviour {
	
	public string SceneName;
	public GUITexture fader;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter() {
		Instantiate(fader);
		StartCoroutine("LoadLevel");
	}
	
	IEnumerator LoadLevel() {
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel(SceneName);
	}
}
