using UnityEngine;
using System.Collections;

public class gm : MonoBehaviour {

	// Game Settings
	public static float initSpeed = 0.2f;		 	// Initial speed of the game.
	public static float speedGlobal = initSpeed; 	// Current speed of the game, refer to this from other scripts.
	public static float parallaxHighMod = 1f;		// Speedmod of the top layer background * globalspeed.
	public static float parallaxMedMod = 0.5f;		// Speedmod of the middle layer background * globalspeed.
	public static float parallaxLowMod = 0.3f;		// Speedmod of the lower layer background * globalspeed.
	public static float speedProgression = 1000f;	// Determines how fast the gamespeed progresses.
	public static float enemySpawnIntervalMod = 1;	// Determines enemy spawnrate.

	// Pause mechanics
	private bool pause;

	public bool Pause
	{
		get { return pause; }
	}

	private static gm instance;
	public static gm Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<gm>();
			}
			return gm.instance;
		}
	}

	// Pause Function
	public void PauseGame () {
		pause = !pause;
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}

		if (Cursor.visible == false) {
			Cursor.visible = true;
		} else {
			Cursor.visible = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Triggers Pause Menu
		if (Input.GetKeyDown(KeyCode.Escape)) {
			PauseGame();
		}
		if (!gm.Instance.Pause) {
			// Accelerates speed of the game
			speedGlobal = initSpeed + Time.time/speedProgression;
			if (lifes.currentLifes > 0) {
				score.currentScore = score.currentScore + speedGlobal/3;
			}
		}
	}
}
