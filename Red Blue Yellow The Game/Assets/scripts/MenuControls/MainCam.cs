using UnityEngine;
using System.Collections;

public class MainCam : MonoBehaviour {

	Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		cam.orthographicSize = (Screen.height / 100.0f) / 4f;
	}
}
