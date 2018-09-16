using UnityEngine;
using System.Collections;

public class enemyWhite : MonoBehaviour {
	// Sets up sprite
	public Sprite enemy1white;

	// Sets up audio
	public AudioSource whiteSound;
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
		anim.SetBool("isWhite", true);
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
		tutorialText.text.text = "Oops! You didn't have the right colors to destroy the spaceship. Now try the neutral one!";
			lifes.currentLifes--;
			lifes.text.text = "";
			for (int i = 1; i <= lifes.currentLifes; i++)
		        {
		            lifes.text.text += "+ ";
		        }	
			}	
				
	// Adds score and gives tutorial feedback.
	private void addScore (int amount) {
		whiteSound.Play();
		tutorialText.text.text = "Good job! I forgot how this one worked...";
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
		    	if (PCKeyboardInput.currentPressedKeys != 7) {
		    			playerLifeLoss();
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    	} else if (PCKeyboardInput.currentPressedKeys == 7) {
		    			addScore(50);
		    			anim.SetBool("isDead", true);
		    			enemyDies();
		    	} 
    		}
    	}
    }
}