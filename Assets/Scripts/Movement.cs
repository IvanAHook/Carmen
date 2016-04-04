using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private const float BASESPEED = 2f;

	private CharacterController cc;

	void Awake()
	{
		cc = GetComponent<CharacterController>();
	}

	void Update () {
		PhysicsMove();
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
		if (Input.GetKey(KeyCode.D))
		{
			direction += Vector2.right;
		}
		//Up
		if (Input.GetKey(KeyCode.W))
		{
			direction += Vector2.up;
		}
		//Down
		if (Input.GetKey(KeyCode.S))
		{
			direction += Vector2.down;
		}

		if (direction != Vector2.zero)
		{
			cc.Move(direction.normalized * BASESPEED * Time.deltaTime);
		}

	}

}
