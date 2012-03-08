using UnityEngine;
using System.Collections;

public class BoatswainCall : MonoBehaviour {
	
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime * speed);
	}
}
