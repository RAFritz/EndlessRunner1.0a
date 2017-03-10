using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_L_Script : MonoBehaviour {

	public Transform player;

	private Vector3 position;

	// Use this for initialization
	void Start () {
		position = player.position;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		position.x = player.position.x - 13;
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Platform")
			Destroy (other.gameObject);
	}
}
