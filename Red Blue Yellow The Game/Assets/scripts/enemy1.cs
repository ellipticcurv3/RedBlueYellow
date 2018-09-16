using UnityEngine;
using System.Collections;

public class enemy1 : MonoBehaviour {
	// Sprite options
	public Sprite enemy1neutral;
	public Sprite enemy1red;
	public Sprite enemy1blue;
	public Sprite enemy1purple;
	public Sprite enemy1yellow;
	public Sprite enemy1orange;
	public Sprite enemy1green;
	public Sprite enemy1white;

	// Sounds
	public AudioSource redSound;
	public AudioSource blueSound;
	public AudioSource yellowSound;
	public AudioSource purpleSound;
	public AudioSource greenSound;
	public AudioSource orangeSound;
	public AudioSource whiteSound;
	public AudioSource neutralSound;
	public AudioSource lifeloseSound;

	// Instantiate Animator
	Animator anim;

	//Enemy states
	float xDirection;
	float yDirection;
	bool playerHit = false;
	bool wallHit = false;
	int enemyColor;
	public static bool playerIsDead = false;

	//Generates a random number between 0 and 7
	int randomColor () {
		int colorNumber = Random.Range(0,8);
		return colorNumber;
	}

	void Awake () {
		// Randomises speed of the enemy.
		xDirection = Random.Range(-0.01F, 0.01F);
		yDirection = Random.Range(0.00F, 0.03F);

		// Call animator
		anim  = GetComponent<Animator> ();

		// Generates what color the enemy will spawn in
		enemyColor = randomColor();

		// Applies color.
		if (enemyColor == 0) {
			anim.SetBool("isNeutral", true);
		} else if (enemyColor ==1) {
			anim.SetBool("isRed", true);
		} else if (enemyColor == 2) {
			anim.SetBool("isBlue", true);
		} else if (enemyColor == 3) {
			anim.SetBool("isPurple", true);
		} else if (enemyColor == 4) {
			anim.SetBool("isYellow", true);
		} else if (enemyColor == 5) {
			anim.SetBool("isOrange", true);
		} else if (enemyColor == 6) {
			anim.SetBool("isGreen", true);
		} else if (enemyColor == 7) {
			anim.SetBool("isWhite", true);
		} else {
			print("error: no player color found, enemy will spawn in neutral color");
			this.gameObject.GetComponent<SpriteRenderer>().sprite = enemy1neutral;	
		}
	}

	// Triggers on collision
	void OnCollisionEnter2D(Collision2D coll) {
	        if (coll.gameObject.tag == "Player") {
	        	playerHit =true;
	        }
	        if (coll.gameObject.tag == "wall") {
	        	wallHit =true;
	        }		        
	    }

	// Destroys the enemy
	private void enemyDies () {
		gameObject.GetComponent<Collider2D>().enabled = false;
		Destroy (gameObject, 1);
	}
	
	// Makes the player lose a life and displays it to the HUD.
	private void playerLifeLoss () {
		lifeloseSound.Play();
		lifes.currentLifes--;
		lifes.text.text = "";
		for (int i = 1; i <= lifes.currentLifes; i++)
		       {
		           lifes.text.text += "+ ";
		       }	
		}

	// Adds score
	private void addScore (int amount) {
		score.currentScore = score.currentScore + amount;
	}

    void Update () {
    	if (!gm.Instance.Pause) {

    		// Destroys the enemy if it gets below the screen
	    	if (transform.position.y < -6) {
	    		Destroy (gameObject);
	    	}

	    	// Adds movement to the enemy
	    	transform.Translate(xDirection, (-gm.speedGlobal/5) - yDirection, 0);

	    	// Bounces the enemy back once it hits a wall
	    	if (wallHit == true) {
	    		xDirection *= -1F;
	    		wallHit = false;
	    	}

	    	// Checks the player color vs the enemy color and takes action appropiately
	    	if (playerHit == true){
	    		playerHit = false;
		    	if (PCKeyboardInput.currentPressedKeys == 0) {
		    		if (enemyColor == 0) {
		    			neutralSound.Play();
		    			addScore(50);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					}
		    	} else if (PCKeyboardInput.currentPressedKeys == 1) {
		    		if (enemyColor == 1) {
		    			redSound.Play();
		 	    		addScore(50);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					} 
		    	} else if (PCKeyboardInput.currentPressedKeys == 2) {
		    		if (enemyColor == 2) {
		    			blueSound.Play();
		    			addScore(50);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					} 
		    	} else if (PCKeyboardInput.currentPressedKeys == 3) {
		    		if (enemyColor == 3) {
		    			purpleSound.Play();
		    			addScore(100);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					} 
		    	} else if (PCKeyboardInput.currentPressedKeys == 4) {
		    		if (enemyColor == 4)  {
		    			yellowSound.Play();
		    			addScore(50);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					} 
		    	} else if (PCKeyboardInput.currentPressedKeys == 5) {
		    		if (enemyColor == 5)  {
		    			orangeSound.Play();
		    			addScore(100);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					} 
		    	} else if (PCKeyboardInput.currentPressedKeys == 6) {
		    		if (enemyColor == 6)  {
		    			greenSound.Play();
		    			addScore(100);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					} ;
		    	} else if (PCKeyboardInput.currentPressedKeys == 7) {
		    		if (enemyColor == 7) {
		    			whiteSound.Play();
		    			addScore(500);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    		} else {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
					} 
		    	}
    		}
    	}
    }
}