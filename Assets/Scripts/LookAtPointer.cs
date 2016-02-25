using UnityEngine;
using System.Collections;

public class LookAtPointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
