﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlatformPowerupSpawner : MonoBehaviour {

	int toSpawn;

	float x;
	float y;
	float z = 0f;

	Vector3 position;

	public Transform[] powerupPrefabs;
	public Transform[] powerdownPrefabs;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		toSpawn = Random.Range (0, 40);
		int playerSpriteNum = player.gameObject.GetComponent<Player> ().getSpriteNum();
		if (toSpawn <= 4) {
			x = Random.Range (-1, 1);
			y = Random.Range (3, 5);
			x += transform.parent.position.x;
			y += transform.parent.position.y;
			position = new Vector3 (x, y, z);
			if (playerSpriteNum == 0) {
				Instantiate (powerupPrefabs [0], position, Quaternion.identity);
			} else if (playerSpriteNum == 4) {
				Instantiate (powerdownPrefabs [3], position, Quaternion.identity);
			} else {
				int upOrDownPower = Random.Range (0, 10);
				if (upOrDownPower <= 4) {
					Instantiate (powerupPrefabs [playerSpriteNum], position, Quaternion.identity);
				} else {
					Instantiate (powerdownPrefabs [playerSpriteNum - 1], position, Quaternion.identity);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
