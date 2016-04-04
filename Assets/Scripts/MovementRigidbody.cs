using UnityEngine;
using System.Collections;

public class MovementRigidbody : MonoBehaviour {

	private const float BASESPEED = 2f;

	private Rigidbody2D rb2d;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Move();
	}

	private void Move()
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
			rb2d.MovePosition(direction.normalized * BASESPEED * Time.deltaTime);
			//cc.Move(direction.normalized * BASESPEED * Time.deltaTime);
		}

	}
}
