using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

namespace Playground
{
	public class TestItem : MonoBehaviour 
	{
		public RectTransform inventory;

		private float offsetX = 390;
		private float offsetY = 268;
		private int itemPosition = 0;
		private int itemHeight = 109;

		void OnEnable()
		{
			Debug.Log("OnEnable");
		}

		void Update()
		{
			UpdatePosition();
		}

		public void ShowPanel(int item)
		{
			itemPosition = item * itemHeight;
			UpdatePosition();

			gameObject.SetActive(true);
		}

		public void HidePanel()
		{
			gameObject.SetActive(false);
		}

		private void UpdatePosition()
		{
			Vector2 position = new Vector2(inventory.localPosition.x - offsetX, inventory.localPosition.y + offsetY - itemPosition);
			GetComponent<RectTransform>().localPosition = position;
		}
	}
}