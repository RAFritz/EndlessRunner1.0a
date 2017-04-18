using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Start_Manager : MonoBehaviour {

	public Transform player;

	private Vector3 transformRotation = new Vector3(0f, 0f, -225f);

	public Sprite [] playerSprites;
	private int spriteNum = 1;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpriteChange", 7, 7);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
			SceneManager.LoadScene ("Scene_Main");
		player.transform.Rotate (transformRotation * Time.deltaTime);
	}

	void SpriteChange() {
		if (spriteNum < playerSprites.Length) {
			player.GetComponent<SpriteRenderer> ().sprite = playerSprites [spriteNum];
			spriteNum++;
		} else if (spriteNum == playerSprites.Length)
			spriteNum = 0;
	}
}
