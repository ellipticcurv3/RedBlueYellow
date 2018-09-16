using UnityEngine;
using System.Collections;

public class BGscrollMed : MonoBehaviour {

	private float speedMed = gm.speedGlobal * gm.parallaxMedMod;
	
	// Use this for initialization
	void Start () {

	
	}

	// Update is called once per frame
	void Update () {
		if (!gm.Instance.Pause) {
		speedMed = gm.speedGlobal * gm.parallaxMedMod;
		Vector2 offset = new Vector2 (0, Time.time * speedMed);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
		}
	}
}
