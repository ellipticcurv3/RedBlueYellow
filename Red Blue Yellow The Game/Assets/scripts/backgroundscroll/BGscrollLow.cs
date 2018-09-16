using UnityEngine;
using System.Collections;

public class BGscrollLow : MonoBehaviour {

	private float speedLow = gm.speedGlobal * gm.parallaxLowMod;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gm.Instance.Pause) {
		speedLow = gm.speedGlobal * gm.parallaxLowMod;
		Vector2 offset = new Vector2 (0, Time.time * speedLow);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
}
