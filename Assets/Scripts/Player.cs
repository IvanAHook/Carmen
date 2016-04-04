using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
[RequireComponent(typeof(LookAtPointer))]
public class Player : MonoBehaviour
{
	private Controller _controller;
	private float _baseSpeed = 150f;

	void Start()
	{
		_controller = GetComponent<Controller>();
	}

	void Update()
	{
		_controller.UpdateCursor();
	}

	void FixedUpdate()
	{
		UpdatePlayerInput();
	}

	private void UpdatePlayerInput()
	{
		if (Input.GetKey(KeyCode.P))
		{
			UIPrintingDialouge.Instance.StartPrint(transform, "Godag kära vän!");
		}
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

		// Move player
		if (direction != Vector2.zero)
		{
			_controller.Move(direction.normalized * _baseSpeed * Time.deltaTime);
		}
		else
		{
			//_controller.Move(Vector2.zero);
		}

	}

}
