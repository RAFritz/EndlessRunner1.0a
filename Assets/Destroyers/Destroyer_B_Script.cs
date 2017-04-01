using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Destroyer_B_Script : MonoBehaviour {

	public Transform player;

	public Vector3 position;

	// Use this for initialization
	void Start () {
		//position = player.position;
	}

	void FixedUpdate() {
		position.x = player.position.x - 5;
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
            player.GetComponent<Player>().setIsDead(true);
			Time.timeScale = 0;
		} 
	}
}
