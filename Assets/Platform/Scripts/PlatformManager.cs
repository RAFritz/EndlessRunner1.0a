﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public Transform[] prefabs;

	public Transform player;

	public Vector3 startPosition;
	private Vector3 nextPosition;

	private float distanceBetween = 2;

	public float platformOffset;

	// Use this for initialization
	void Start () {
		nextPosition = startPosition;
		//Instantiate (prefabs [0], nextPosition, Quaternion.identity);
		//nextPosition.x += prefabs [0].GetComponent<BoxCollider2D> ().bounds.size.x + distanceBetween;
		//Transform plat = Instantiate (prefabs[2], nextPosition, Quaternion.identity);
		//BoxCollider2D bc2d = plat.GetComponent<BoxCollider2D> ();
		//Debug.Log (plat.position.x + " " + bc2d.bounds.size.x);
		//nextPosition.x += bc2d.bounds.size.x + 5;
		InvokeRepeating("IncreaseDistance", 40, 40);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GeneratePlatforms (distanceBetween);
	}

	void GeneratePlatforms(float dB) {
		while (nextPosition.x < player.position.x + platformOffset) {
			Transform plat = Instantiate(prefabs[Random.Range(0, prefabs.Length)], nextPosition, Quaternion.identity);
			nextPosition.x += plat.GetComponent<BoxCollider2D> ().bounds.size.x + dB;
		}

	}

	void IncreaseDistance() {
		distanceBetween++;
	}
}