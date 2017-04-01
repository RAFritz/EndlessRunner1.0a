using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRotate : MonoBehaviour {

	int currentSpriteNum;

	private GameObject player;

	public Sprite[] playerSprites;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		currentSpriteNum = player.gameObject.GetComponent<Player> ().getSpriteNum ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (0f, 0f, -90f * Time.deltaTime);
		if(currentSpriteNum != player.gameObject.GetComponent<Player> ().getSpriteNum () && currentSpriteNum != playerSprites.Length)
			GetComponent<SpriteRenderer> ().sprite = playerSprites[player.gameObject.GetComponent<Player> ().getSpriteNum () + 1];
	}
}
