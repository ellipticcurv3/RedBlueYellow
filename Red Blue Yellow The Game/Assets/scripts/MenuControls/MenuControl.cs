using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	public GameObject	GameOverMenu,
						PauseMenu;

	void Awake(){
		// Sets all menu's inactive on game start.
		GameOverMenu.SetActive(false);
		PauseMenu.SetActive(false);
	}

	// Buttons.
	public string StartButtonScene;
	public string MainMenuButtonScene;
	
	// Resets the game.
	public void start(){      
		gm.speedGlobal = gm.initSpeed; 
		Application.LoadLevel(StartButtonScene);
	}

	// Quits the game.
	public void quit(){
		Application.Quit();
	}
	
	// Loads main menu.
	public void mainMenu(){
		Application.LoadLevel(MainMenuButtonScene);		
	}
}