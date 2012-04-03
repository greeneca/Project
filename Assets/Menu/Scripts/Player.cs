using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	static Vector3 position = new Vector3(0, 0, 0);
	static Quaternion rotation = new Quaternion(0, 0, 0, 0);
	public static readonly int stations = 6;
	public static bool[] stationStatus = null;
	public static int[] stationScore = null;
	
	
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
		if(stationScore == null || stationStatus == null){
			//initialize stations
			stationStatus = new bool[stations];
			stationScore = new int[stations];
			for(int i = 0; i < stations; i++){
				stationStatus[i] = false;
				stationScore[i] = -1;
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
		//Debug.Log(stationStatus[1]);
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
}
