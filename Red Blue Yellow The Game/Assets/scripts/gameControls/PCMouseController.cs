using UnityEngine;
using System.Collections;

public class PCMouseController : MonoBehaviour {

	private Vector2 playerPosition;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Checks mouse input
		if (!gm.Instance.Pause) {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;
		this.gameObject.transform.position = pz;
	}
	}
}
