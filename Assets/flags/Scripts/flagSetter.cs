using UnityEngine;
using System.Collections;
using System;
public class flagSetter : MonoBehaviour {
	
	// HUD
	public Texture2D[] flags;
	public GUITexture flagGUI;
	// Use this for initialization
	
	static System.Random r = new System.Random();
	
	void Start () {
	int n = r.Next() % 26;
    Console.WriteLine(n);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


/*
static Random _r = new Random();
    static void F()
    {
	// Use class-level Random so that when this
	// ... method is called many times, it still has
	// ... good Randoms.
	int n = _r.Next();
	// If this declared a local Random, it would
	// ... repeat itself.
	Console.WriteLine(n);
	
	*/