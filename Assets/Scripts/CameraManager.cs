using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {

	public Transform player;

	public GameObject gameOverTextHolder;

    public Button pauseBtn;

	void Update () 
	{
		transform.position = new Vector3 (player.position.x + 6, 0, -10); // Camera follows the player but 6 to the right
		/*if (Time.timeScale == 0) {
			gameOverTextHolder.SetActive (true);
			if(Input.GetMouseButtonDown(0))
				SceneManager.LoadScene ("Scene_Main");
		}*/
        if (Time.timeScale == 0 && player.GetComponent<Player>().getIsDead())
        {
            gameOverTextHolder.SetActive(true);
            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("Scene_Main");
        }
    }

	// Use this for initialization
	void Start () {
		gameOverTextHolder.SetActive (false);
		if (Time.timeScale == 0)
			Time.timeScale = 1;
        Button pbtn = pauseBtn.GetComponent<Button>();
        pbtn.onClick.AddListener(PauseGame);
    }

    void PauseGame()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
}
