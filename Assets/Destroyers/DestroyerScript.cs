using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	public Transform player;

	public Vector3 position;

	// Use this for initialization
	void Start () {
		position = player.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		position.x = player.position.x - 10;
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
			Debug.Break ();
		} 
	}
}
