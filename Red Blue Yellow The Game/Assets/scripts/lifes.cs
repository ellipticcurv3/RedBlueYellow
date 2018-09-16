using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lifes : MonoBehaviour {
	// Initial player lifes
	private static ushort initLifes = 3;

	// Ingame lifetracker, refer to this with other scripts
	public static ushort currentLifes = initLifes; 

	// Reference to the text component
	public static Text text;

	// Reference to the GameOverMenu
	public GameObject GameOverMenu;

	void Start ()
	{
	    // Set up the reference.
	    text = GetComponent <Text> ();

	    // Reset the score.
	    currentLifes = initLifes;
	}

	void Update () {
		// Triggers game over menu when player runs out of lifes
		if (currentLifes <= 0) {
			Cursor.visible = true;
			GameOverMenu.SetActive(true);
		}
	}
}
