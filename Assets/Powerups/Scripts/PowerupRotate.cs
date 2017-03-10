using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (0f, 0f, -90f * Time.deltaTime);
	}
}
