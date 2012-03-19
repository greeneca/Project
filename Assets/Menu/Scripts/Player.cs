using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	static Vector3 position = new Vector3(0, 0, 0);
	
	// Use this for initialization
	void Start () {	
		if(position.x != 0 && position.y != 0 && position.z != 0){
			transform.position = position;
			transform.Translate(new Vector3(0, 0, -10));
			Debug.Log(position);
		}		
	}
	
	// Update is called once per frame
	void Update () {
		position.x = transform.position.x;
		position.y = transform.position.y;
		position.z = transform.position.z;
	}
}
