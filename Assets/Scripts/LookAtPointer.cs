using UnityEngine;

public class LookAtPointer : MonoBehaviour
{

	void Update()
	{
		Vector3 lookAtPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mousePoint = new Vector3(lookAtPoint.x, lookAtPoint.y, 0);

		float angle = GetAngle(transform.position, mousePoint);
		transform.eulerAngles = new Vector3(0, 0, angle);
	}

	private float GetAngle(Vector3 currentLocation, Vector3 mouseLocation)
	{
		float x = mouseLocation.x - currentLocation.x;
		float y = mouseLocation.y - currentLocation.y;

		return Mathf.Rad2Deg * Mathf.Atan2(y, x) - 90;
	}

}
