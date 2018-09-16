using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tutorialText : MonoBehaviour {
	public static Text text; 
	void Start ()
	{
	    // Set up the reference.
	    text = GetComponent <Text> ();
	}

	void Update () {
		// Ends the tutorial after 34 seconds of game time.
		if ( Time.time > 34 && Time.time < 36) {
			text.text = "I suddenly realise I don't have time for this. You're on your own now. Good luck young space traveler :)";
			} else if (Time.time > 37) {
				text.text = "";
			}
		}
	}

