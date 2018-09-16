using UnityEngine;
using System.Collections;

public class BGscrollHigh : MonoBehaviour {

/*	GameObject go = GameObject.Find ("MainCamera");
	gm gamemaster = go.GetComponent <gm> ();
	float speedmaardananders = gamemaster.speed; */

	private float speedHigh = gm.speedGlobal * gm.parallaxHighMod;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gm.Instance.Pause) {
		speedHigh = gm.speedGlobal * gm.parallaxHighMod;
		Vector2 offset = new Vector2 (0, Time.time * speedHigh);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
	}
}
