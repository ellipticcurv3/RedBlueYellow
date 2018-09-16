using UnityEngine;
using System.Collections;

public class randomGeneration: MonoBehaviour {
	
 /* Public transform */
	
 public Transform enemyPrefab;
	
 /* Timers */
	
 private float	lastTimerDecrement = 0f;
 private float	lastEnemySpawnTime = 0f;
 public  float	scriptExecWaitTime = 10f; // De tijdsverloop alvorens het uitvoeren van het script.
 private bool	playing		   	   = false;
 

 /* Enemies */
	
 public ushort	numberOfEnemiesOnGameStart 			= 5;
 public float	enemySpawnInterval 					= 5f;
 public float	enemySpawnTimeDecrement 			= 0.0005f;
 public float	minimumEnemySpawnInterval 			= 1f;
 public ushort	numberOfEnemiesToSpawnOnInterval	= 2;
 
 private bool 	enemyAlreadySpawned = false;

 /* Spawn requirements */
	
 public float	spawnMinimumXPosition = -8f;
 public float	spawnMaximumXPosition =  8f;
 public float	spawnMinimumYPosition = -4f;
 public float	spawnMaximumYPosition =  4f;
 public float	minimumSpawnDistanceX = 0.2f;
 public float	minimumSpawnDistanceY = 0.2f;
	
/*
 * CUSTOM METHODS
 * Dit zijn de functies gemaakt voor de random generation
 */

public void spawnRandomEnemies(int numberOfEnemiesToSpawn) {
if (playing)
{
 /*
  * Onderstaande stuk code maakt willekeurige coördinaten aan om een enemy prefab op te spawnen.
  *
  * De coördinaten voldoen aan bepaalde voorwaarden zodat het spel speelbaar blijft; want bij random generation
  * is de kans groot dat de verdeling onevenredig is. In een spel is dit niet gewenst omdat dit het spel onspeelbaar maakt.
  * Zodoende zorgt de code dat de willekeurigheid "gestuurd" is: Er zit een minimale afstand tussen plekken om te spawnen.
  *
  */

 // Om te bereiken dat de code weet waar de vorige plek van het object was wordt er gebruik gemaakt van lokale variabelen previousXValue && previousYValue
	
float previousXValue = 0f;
float previousYValue = 0f;

 // Vervolgens wordt er gebruik gemaakt van een for loop om het aantal prefabs dat je wil spawnen repititief uit te voeren.
for (int i = 1; i <= numberOfEnemiesToSpawn; i = i + 1) {

 // Er worden twee willekeurige getallen bedacht en opgeslagen in variabelen.
float currentXValue = Random.Range(spawnMinimumXPosition, spawnMaximumXPosition);
float currentYValue = Random.Range(spawnMinimumYPosition, spawnMaximumYPosition);

  /*
   * WHILE LOOPS (X-as & Y-as)
   * Om de willekeurigheid te sturen zijn er twee while-loops.
   * Deze zorgen ervoor dat er een minimumafstand zit tussen de vorige waarde en huidige waarde.
   *
   */

while ((System.Math.Abs(currentXValue) + System.Math.Abs(previousXValue)) < minimumSpawnDistanceX) {
//print("currentXValue (" + currentXValue + ") en previousXValue (" + previousXValue + ") verschillen minder dan minimumSpawnDistanceX (" + minimumSpawnDistanceX + ").");
currentXValue = Random.Range(spawnMinimumXPosition, spawnMaximumXPosition);
}

while ((System.Math.Abs(currentYValue) + System.Math.Abs(previousYValue)) < minimumSpawnDistanceY) {
//print("currentYValue (" + currentYValue + ") en previousYValue (" + previousYValue + ") verschillen minder dan minimumSpawnDistanceY (" + minimumSpawnDistanceY + ").");
currentYValue = Random.Range(spawnMinimumYPosition, spawnMaximumYPosition);
}


/*
* INSTANTIATE
* Maakt een kloon van een object. Deze code zorgt dat er een enemy op het scherm komt.
* (2*spawnMaximumYPosition) zorgt ervoor dat hij boven het scherm komt.
*
*/

Instantiate(enemyPrefab, new Vector3(currentXValue, currentYValue + (2 * spawnMaximumYPosition), 0), Quaternion.identity);

// Niet vergeten de huidige X en Y voor de volgende keer op te slaan.
previousXValue = currentXValue;
previousYValue = currentYValue;

}
}

}

void checkIntervalAndSpawnEnemies(int numberOfEnemiesToSpawn) {
	 if ((!enemyAlreadySpawned) && (Time.time - lastEnemySpawnTime > enemySpawnInterval))
		{
		  lastEnemySpawnTime = Time.time;
		  spawnRandomEnemies(numberOfEnemiesToSpawn);
		  enemyAlreadySpawned = true;
		}

	if(Time.time - lastEnemySpawnTime > (enemySpawnInterval - 2))
		{
			enemyAlreadySpawned = false;
		}
	}

void decrementSpawntimer(){

		/*
		 * De onderstaande code wordt elk frame aangeroepen via update en
		 * trekt [enemySpawnTimeDecrement] af van [enemySpawnInterval]
		 *
		 */
			if ((Time.time - lastTimerDecrement <= enemySpawnInterval) && (enemySpawnInterval > minimumEnemySpawnInterval) && playing)
			{
				enemySpawnInterval = enemySpawnInterval - enemySpawnTimeDecrement;
				lastTimerDecrement = Time.time;

				// Quick-fix omdat enemySpawnInterval soms net even onder de minimumEnemySpawnInterval uit komt
				if (enemySpawnInterval < minimumEnemySpawnInterval)
				{
					enemySpawnInterval = minimumEnemySpawnInterval;
				}
			}
	}

/*
 * QUICK-FIX: WAIT-WRAPPER
 *
 * Invoke(string, float); verwacht een string met de naam van de methode.
 * Het is dus niet mogelijk om Invoke(spawnRandomEnemies(numberOfEnemiesOnGameStart), 5); uit te voeren.
 * Op deze manier kan het wel.
 *
 */

void doAfterWait(){
	playing = true;
	spawnRandomEnemies(numberOfEnemiesOnGameStart);
	lastTimerDecrement = Time.time;
}

	
/*
 * STANDAARD METHODS
 *
 * Dit zijn de functies van Unity. De code bij start wordt bij het starten uitgevoerd, de code in update wordt ieder frame uitgevoerd.
 *
 */
	
 void Start() {
  	 Invoke("doAfterWait", scriptExecWaitTime);  // Invoke voert een functie (method) uit na een aantal seconden.
 }
	
 void Update() {
	 checkIntervalAndSpawnEnemies(numberOfEnemiesToSpawnOnInterval);
	 decrementSpawntimer();
 }

}