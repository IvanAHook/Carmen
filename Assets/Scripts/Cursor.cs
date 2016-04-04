using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	public Texture2D CursorTexture;
	public Texture2D CursorTextureMouseOver;
	public Texture2D CursorTextureTalk;
	CursorMode CursorMode = CursorMode.Auto;
	Vector2 HotSpot = new Vector2(16, 16);

	void Start()
	{
		UnityEngine.Cursor.SetCursor(CursorTexture, HotSpot, CursorMode);
	}

	void Update()
	{
		var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
			Vector2.down, 1f);

		if (hit)
		{
			if (hit.transform.tag == "NPC")
			{
				UnityEngine.Cursor.SetCursor(CursorTextureTalk, HotSpot, CursorMode);
			}
			else
			{
				UnityEngine.Cursor.SetCursor(CursorTextureMouseOver, HotSpot, CursorMode);
			}
		}
		else
		{
			UnityEngine.Cursor.SetCursor(CursorTexture, HotSpot, CursorMode);
		}
	}

}
