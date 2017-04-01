using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2d;

	private float speed = 2.5f;

	private float distanceTraveled;

	private Vector2 jumpVelocity = new Vector2(0f, 300f);

	private bool isGrounded;

	public Text txtRef;

	private int score;

	public Sprite [] playerSprites;
	private int spriteNum = 0;

    private bool isDead;

	private int numJumps = 0;

	private int powerupScore;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("SetSpeed", 60, 60);
        isDead = false;
		powerupScore = 0;
	}

    void FixedUpdate() {
        distanceTraveled = transform.localPosition.x;
		score = (int)distanceTraveled + 7 + powerupScore;

        txtRef.text = "Score: " + score;
        int direction = 1;
        isGrounded = gameObject.GetComponent<GroundHitCheck>().GetGrounded();
		if (isGrounded)
			numJumps = 1;
		if (numJumps > 0) {
			if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() ) {
				rb2d.velocity = new Vector2 (direction * speed, 0f);
                rb2d.AddForce(jumpVelocity);
				numJumps--;
            }
        }
		rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
	}

	void SetSpeed() {
		speed++;
		if (spriteNum < playerSprites.Length - 1) {
			spriteNum++;
		}
		GetComponent<SpriteRenderer> ().sprite = playerSprites[spriteNum];
		GetComponent<CircleCollider2D>().offset = Vector2.zero;

	}

	public int getSpriteNum() {
		return this.spriteNum;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Powerup") {
			SetSpeed ();
			if (score + powerupScore > 100)
				powerupScore -= 100;
			else
				powerupScore = 0 - (int)distanceTraveled - 7;
		} else if (other.gameObject.tag == "Powerdown") {
			DecreaseSpeed ();
			powerupScore += 100;
		}
		Destroy (other.gameObject);
	}

	void DecreaseSpeed() {
		speed--;
		spriteNum--;
		GetComponent<SpriteRenderer> ().sprite = playerSprites [spriteNum];
	}

    public bool getIsDead()
    {
        return isDead;
	}

    public void setIsDead(bool d)
    {
        isDead = d;
    }

	public int GetScore() {
		return score + powerupScore;
	}
}
