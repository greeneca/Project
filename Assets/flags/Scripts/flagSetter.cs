using UnityEngine;
using System.Collections;
using System;
public class flagSetter : MonoBehaviour {
	
	// HUD
	public Texture2D[] flags;
	//public GUITexture flagGUI;
	public Texture2D flagGUI;
	// Use this for initialization
	public String[] flagnames = {"Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", 
		"Golf", "Hotel", "India", "Juliet", "Kilo", "Lima", "Mike", "November", "Oscar", 
		"Papa", "Quebec", "Romeo", "Sierra", "Tango", "Uniform", "Victor", "Whiskey", 
		"Xray", "Yankee", "Zulu"};
	
		public String[] answers = {"", "", "", ""};
	
	
	static System.Random r = new System.Random();
	
	public Rect menuArea;
    void buildQuestion()
	{
		int n = r.Next() % 26;
	    flagGUI = flags[n];
        Debug.Log(n);
	    Debug.Log(flagnames[n]);
		int x = r.Next() % 4;
		Debug.Log(x);
		answers[x] = flagnames[n];
		Debug.Log(answers[x]);
		
	    for (int i = 0; i <= 3; i++)
		{
			
			int k = r.Next() % 26;
			
			if(answers[i].Equals(""))
			{
				answers[i] = flagnames[k];
				//Debug.Log(answers[i]);
				
			}
			
					
		}
		for (int b = 0; b <= 3; b++)
		{
			Debug.Log("I'm in the last loop" + answers[b]);
		}
	}
	
	void Start () {
	buildQuestion();
	}
	
	// Update is called once per frame
	void Update () {
	renderer.material.SetTexture("_MainTex", flagGUI);
	}
}


