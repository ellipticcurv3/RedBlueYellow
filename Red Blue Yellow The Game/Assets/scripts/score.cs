using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour
{
    // Keeps track of the player score.
	public static float currentScore = 0;

    // Reference to the Text component.
    public static Text text;                      

    void Awake ()
    {
        // Set up the reference.
        text = GetComponent <Text> ();

        // Reset the score.
        currentScore = 0;
    }

    void Update ()
    {
        if (!gm.Instance.Pause) {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + (int) currentScore;
    }
    }
}