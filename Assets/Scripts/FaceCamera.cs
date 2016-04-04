using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	Camera cam;

	void Start () {
		cam = Camera.main;

		Vector3 fwd = cam.transform.forward;
		transform.rotation = Quaternion.LookRotation(fwd);
	}

}
