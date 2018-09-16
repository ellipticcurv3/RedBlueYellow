using UnityEngine;
using System.Collections;

public class enemyYellow : MonoBehaviour {
	// Sets up sprite
	public Sprite enemy1yellow;

	// Sets up audio
	public AudioSource yellowSound;
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
		anim.SetBool("isYellow", true);
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
		tutorialText.text.text = "Oops! You didn't have the right color to destroy the spaceship. Combine 1 & 2 to destroy the purple spaceship.";
			lifes.currentLifes--;
			lifes.text.text = "";
			for (int i = 1; i <= lifes.currentLifes; i++)
		        {
		            lifes.text.text += "+ ";
		        }	
			}
	
	// Adds score and gives tutorial feedback.
	private void addScore (int amount) {
		yellowSound.Play();
		tutorialText.text.text = "Now press 1 and 2 at the same time to destroy the purple spaceship.";
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
		    	if (PCKeyboardInput.currentPressedKeys != 4) {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    	} else if (PCKeyboardInput.currentPressedKeys == 4) {
		    			addScore(50);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    	} 
    		}
    	}
    }
}