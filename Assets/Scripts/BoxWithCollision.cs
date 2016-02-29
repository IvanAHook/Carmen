using UnityEngine;
using System.Collections;

public class BoxWithCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log("LALLA");
	}
}
