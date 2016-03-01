using UnityEngine;
using System.Collections;

public class LookAtPointer : MonoBehaviour {

	private const float BASESPEED = 2f;

	private CharacterController cc;

	void Awake()
	{
		cc = GetComponent<CharacterController>();
	}

	void Update()
	{
		Vector3 lookAtPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mousePoint = new Vector3(lookAtPoint.x, lookAtPoint.y, 0);

		float angle = GetAngle(transform.position, mousePoint);
		transform.eulerAngles = new Vector3(0, 0, angle);

		PhysicsMove();
		//Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1);
	}

	private void PhysicsMove()
	{
		Vector2 direction = Vector2.zero;
		//Left
		if (Input.GetKey(KeyCode.A))
		{
			direction += Vector2.left;
		}
		//Right
		if(Input.GetKey(KeyCode.D)){
			direction += Vector2.right;
		}
		//Up
		if (Input.GetKey(KeyCode.W)){
			direction += Vector2.up;
		}
		//Down
		if(Input.GetKey(KeyCode.S)){
			direction += Vector2.down;
		}

		if (direction != Vector2.zero)
		{
			cc.Move(direction.normalized * BASESPEED * Time.deltaTime);
			//cc.SimpleMove(direction.normalized * BASESPEED * Time.deltaTime);
			//rb2d.AddForce(direction.normalized * BASESPEED * Time.deltaTime);
		}
			
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
		hit.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*100);
	}

//	void OnCollisionEnter(Collision other)
//	{
//		Debug.Log(other.gameObject.name);
//		other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*100);
//	}

//	void OnTriggerEnter(Collider other)
//	{
//		Debug.Log(other.gameObject.name + " trigger");
//		other.GetComponent<Rigidbody>().AddForce(transform.up);
//	}

}
