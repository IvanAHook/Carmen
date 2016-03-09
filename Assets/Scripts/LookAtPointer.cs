using UnityEngine;
using System.Collections;

public class LookAtPointer : MonoBehaviour {

	void Update()
	{
		Vector3 lookAtPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mousePoint = new Vector3(lookAtPoint.x, lookAtPoint.y, 0);

		float angle = GetAngle(transform.position, mousePoint);
		transform.eulerAngles = new Vector3(0, 0, angle);
	}


	//private void Move(float horizontal, float vertical, float speedModifier) // direction vector normalized for consitent movement speed ples
	//{
	//	float speed = BASESPEED * speedModifier;

	//	Vector2 movement = new Vector3(
	//		transform.position.x + horizontal * speed * Time.deltaTime,
	//		transform.position.y + vertical * speed * Time.deltaTime,
	//		0.0f);

	//	transform.position = movement;
	//}

	private float GetAngle(Vector3 currentLocation, Vector3 mouseLocation)
	{
		float x = mouseLocation.x - currentLocation.x;
		float y = mouseLocation.y - currentLocation.y;

		return Mathf.Rad2Deg * Mathf.Atan2(y, x) - 90;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Debug.Log(hit.gameObject.name);
		//hit.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*0.2f);
	}

}
