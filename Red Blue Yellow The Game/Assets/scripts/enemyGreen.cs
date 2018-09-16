using UnityEngine;
using System.Collections;

public class enemyGreen : MonoBehaviour {
	// Sets up sprite
	public Sprite enemy1green;

	// Sets up audio
	public AudioSource greenSound;
	public AudioSource lifeloseSound;

	// Instantiate Animator
	Animator anim;

	// Enemy states
	bool playerHit = false;
	public static bool playerIsDead = false;
	
	void Awake () {
		// Call animator
		anim  = GetComponent<Animator> ();

		// Sets color
		anim.SetBool("isGreen", true);
	}

	// Triggers when the player hits the enemy
	void OnCollisionEnter2D(Collision2D coll) {
	        if (coll.gameObject.tag == "Player") {
	        	playerHit =true;
	        }		        
	    }

	//Destroys the enemy
	private void enemyDies () {
		gameObject.GetComponent<Collider2D>().enabled = false;
		Destroy (gameObject, 1);
	}

	// Removes 1 life and gives tutorial feedback.
	private void playerLifeLoss () {
			lifeloseSound.Play();
			tutorialText.text.text = "Oops! You didn't have the right colors to destroy the spaceship. Combine 1 & 3 to destroy the orange spaceship.";
				lifes.currentLifes--;
				lifes.text.text = "";
				for (int i = 1; i <= lifes.currentLifes; i++)
			        {
			            lifes.text.text += "+ ";
			        }	
				}
	
	// Adds score and gives tutorial feedback.
	private void addScore (int amount) {
		greenSound.Play();
		tutorialText.text.text = "Allright! Let's try 1 and 3 at the same time to destroy the orange spaceship.";
		score.currentScore = score.currentScore + amount;
	}

    void Update () {
    	if (!gm.Instance.Pause) {

    		// Moves the enemy.
	    	transform.Translate(0, (-gm.speedGlobal/5), 0);

	    	// Destroys enemy if it gets below the screen.
	    	if (transform.position.y < -6) {
	    		Destroy (gameObject);
	    	}

	    	// Checks enemy color vs player color and handles appropiately.
	    	if (playerHit == true){
	    		playerHit = false;
		    	if (PCKeyboardInput.currentPressedKeys != 6) {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    	} else if (PCKeyboardInput.currentPressedKeys == 6) {
		    			addScore(50);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    	} 
    		}
    	}
    }
}