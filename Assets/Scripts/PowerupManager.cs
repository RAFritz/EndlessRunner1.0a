using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	public Transform[] powerupPrefabs;
	public Transform[] powerdownPrefabs;

	public Transform player;

	public System.Random rand = new System.Random();

	private int spawnRate;

	//private Transform powerup;

	//private Vector3 powerupRotation = new Vector3(0f, 0f, -180f);

	// Use this for initialization
	void Start () {
		spawnRate = rand.Next (5, 35);
		Invoke ("PowerSpawn", spawnRate);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void PowerSpawn() {
		int playerSpriteNum = player.gameObject.GetComponent<Player> ().getSpriteNum();
		float powerPos = Random.Range(-2, 0);
		Vector3 position = new Vector3 (player.position.x + 20f, powerPos, player.position.z);
		if (playerSpriteNum == 0) {
			Instantiate (powerupPrefabs [0], position, Quaternion.identity);
		} else if (playerSpriteNum == 4) {
			Instantiate (powerdownPrefabs [3], position, Quaternion.identity);
		} else {
			int upOrDownPower = rand.Next (0, 10);
			if (upOrDownPower <= 4) {
				Instantiate (powerupPrefabs [playerSpriteNum], position, Quaternion.identity);
			} else {
				Instantiate (powerdownPrefabs [playerSpriteNum], position, Quaternion.identity);
			}
		}
		spawnRate = rand.Next (5, 35);
		Invoke ("PowerSpawn", spawnRate);
	}
}
