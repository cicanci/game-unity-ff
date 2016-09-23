using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Playground
{
	public class TestChangeScene : MonoBehaviour
	{
		public Texture2D cursorTexture;
		public CursorMode cursorMode = CursorMode.Auto;
		public Vector2 hotSpot = Vector2.zero;
		public bool enableCursor = false;

		void Start()
		{
			Debug.LogWarning("Playground::TestChangeScene script is in use by " + gameObject.name);

			if (enableCursor)
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
			if (enableCursor)
			{
				AddCursor();
			}
		}

		void OnMouseExit() 
		{
			if (enableCursor)
			{
				RemoveCursor();
			}
		}

		private void AddCursor()
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			Cursor.visible = true;
		}

		private void RemoveCursor()
		{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
			Cursor.visible = false;
		}
	}

}
