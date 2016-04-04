using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;
	private Camera _cam;

	void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_cam = Camera.main;
	}

	public void Move(Vector3 motion)
	{
		_rigidbody2D.velocity = motion;
	}

	public void UpdateCursor()
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(_cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		foreach (var hit in hits)
		{
			if (hit.collider == null) continue;


			if (hit.transform.tag == "NPC" && (hit.transform.position - transform.position).magnitude < 1)
			{
				if (Input.GetMouseButtonDown(0))
				{
					var npc = hit.transform.GetComponent<NPC>();

					npc.Talk(0);

					//Dialogue.Instance.OpenDialogue(npc.Dilaogue());
				} 

			}

		}
	}

}
