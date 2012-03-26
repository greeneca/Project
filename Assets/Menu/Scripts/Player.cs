using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	static Vector3 position = new Vector3(0, 0, 0);
	public readonly int stations = 6;
	public static bool[] stationStatus;
	public static int[] stationScore;
	
	
	// Use this for initialization
	void Start () {	
		//reset position
		if(position.x != 0 && position.y != 0 && position.z != 0){
			transform.position = position;
			transform.Translate(new Vector3(0, 0, -10));
			Debug.Log(position);
		}		
		//initialize stations
		stationStatus = new bool[stations];
		stationScore = new int[stations];
		for(int i = 0; i < stations; i++){
			stationStatus[i] = false;
			stationScore[i] = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		position.x = transform.position.x;
		position.y = transform.position.y;
		position.z = transform.position.z;
	}
}
