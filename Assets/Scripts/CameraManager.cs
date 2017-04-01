using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class CameraManager : MonoBehaviour {

	public Transform player;

	public GameObject gameOverTextHolder;

    public Button pauseBtn;

	private int highScore;

	public GameObject HighScoreTextHolder;

	private string highScoreKey = "HighScore";

	private int score;

	public Text HighScoreText;

	bool toShowAd;

	void Update () 
	{
		transform.position = new Vector3 (player.position.x + 6, 0, -10); // Camera follows the player but 6 to the right
		if (Time.timeScale == 0 && player.GetComponent<Player> ().getIsDead ()) {
			gameOverTextHolder.SetActive (true);
			HighScoreTextHolder.SetActive (true);
			if (score > highScore) {
				PlayerPrefs.SetInt (highScoreKey, score);
				PlayerPrefs.Save ();
				HighScoreText.text = "High Score: " + score;
			}
			if (Input.GetMouseButtonDown (0)) {
				//ShowAd ();
				if (toShowAd) {
					ShowAd ();
					PlayerPrefs.SetInt ("NumLoads", 1);
				} else if (PlayerPrefs.GetInt ("NumLoads") == 1) {
					PlayerPrefs.SetInt ("NumLoads", 2);
				} else {
					PlayerPrefs.SetInt ("NumLoads", 0);
				}
				SceneManager.LoadScene ("Scene_Main");
			}

		}
		score = player.gameObject.GetComponent<Player> ().GetScore ();
    }

	// Use this for initialization
	void Start () {
		gameOverTextHolder.SetActive (false);
		HighScoreTextHolder.SetActive (false);
		highScore = PlayerPrefs.GetInt(highScoreKey,0); 
		HighScoreText.text = "High Score: " + highScore;
		if (Time.timeScale == 0)
			Time.timeScale = 1;
        Button pbtn = pauseBtn.GetComponent<Button>();
        pbtn.onClick.AddListener(PauseGame);
		//toShowAd = true;
		toShowAd = PlayerPrefs.GetInt("NumLoads") == 0;
    }

    void PauseGame()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	void Awake() {
		if (PlayerPrefs.HasKey ("NumLoads")) {
		} else
			PlayerPrefs.SetInt ("NumLoads", 0);
	}
}
