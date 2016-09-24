using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Playground
{
	public enum CursorType
	{
		Small, Big, None
	}

	public class TestChangeScene : MonoBehaviour
	{
		public Texture2D cursorTextureSmall;
		public Vector2 hotSpotSmall = Vector2.zero;
		public Texture2D cursorTextureBig;
		public Vector2 hotSpotBig = Vector2.zero;
		public CursorMode cursorMode = CursorMode.Auto;
		public CursorType cursorType = CursorType.None;

		void Start()
		{
			Debug.LogWarning("Playground::TestChangeScene script is in use by " + gameObject.name);

			if (cursorType != CursorType.None)
			{
				AddCursor();
			}
			else 
			{
				RemoveCursor();
			}
		}

		void Update()
		{
			if (Input.GetButtonDown("Fire2"))
			{
				if (SceneManager.GetActiveScene().name == "Playground")
				{
					SceneManager.LoadScene("PlaygroundUI");
				}
				else if (SceneManager.GetActiveScene().name == "PlaygroundUI")
				{
					SceneManager.LoadScene("Playground");
				}
			}
		}

		void OnMouseEnter() 
		{
			if (cursorType != CursorType.None)
			{
				AddCursor();
			}
		}

		void OnMouseExit() 
		{
			if (cursorType != CursorType.None)
			{
				RemoveCursor();
			}
		}

		private void AddCursor()
		{
			if (cursorType == CursorType.Small)
			{
				Cursor.SetCursor(cursorTextureSmall, hotSpotSmall, cursorMode);
			}
			else if (cursorType == CursorType.Big)
			{
				Cursor.SetCursor(cursorTextureBig, hotSpotBig, cursorMode);
			}

			Cursor.visible = true;
		}

		private void RemoveCursor()
		{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
			Cursor.visible = false;
		}
	}

}
