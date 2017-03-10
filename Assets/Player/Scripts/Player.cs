using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2d;

	private float speed = 2.5f;

	private float distanceTraveled;

	private Vector2 jumpVelocity = new Vector2(0f, 300f);

	//private bool touchingPlatform;

	private bool isGrounded;

	public Text txtRef;

	private int score;

	public Sprite [] playerSprites;
	private int spriteNum = 0;

    private bool isDead;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("SetSpeed", 40, 40);
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate() {
        distanceTraveled = transform.localPosition.x;
        score = (int)distanceTraveled + 7;
        txtRef.text = "Score: " + score;
        int direction = 1;
        isGrounded = gameObject.GetComponent<GroundHitCheck>().GetGrounded() && rb2d.position.y >= -2.7f;
        //Debug.Log(isGrounded + " " + rb2d.position.y);
        //if((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) ) && touchingPlatform)
        if (isGrounded) {
			if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() ) {
				rb2d.velocity = new Vector2 (direction * speed, 0f);
                rb2d.AddForce(jumpVelocity);
            }
        }
		rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
		//Vector2 movement = new Vector2 (1f, 0f);
		//rb2d.AddForce (movement * speed);
	}

	//void OnCollisionEnter2D() {
	//	touchingPlatform = true;
	//}

	//void OnCollisionExit2D() {
	//	touchingPlatform = false;
	//}

	void SetSpeed() {
		speed++;
		if (spriteNum < playerSprites.Length) {
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
		} else if (other.gameObject.tag == "Powerdown") {
			DecreaseSpeed ();
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
}
