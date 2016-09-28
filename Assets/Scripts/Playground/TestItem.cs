﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

namespace Playground
{
	public class TestItem : MonoBehaviour 
	{
		public RectTransform inventory;
		public GameObject inventoryExpand;

		private int offsetX = 390;
		private int offsetY = 268;
		private int itemPositionX = 0;
		private int itemPositionY = 0;
		private int itemHeight = 109;
		private int expandWidth = 250;

		void Start()
		{
			Debug.LogWarning("Playground::TestItem script is in use by " + gameObject.name);
		}

		void Update()
		{
			UpdatePosition();
		}

		public void ShowPanel(int item)
		{
			if (item > 4)
			{
				itemPositionX = (offsetX * 2) + expandWidth;
				itemPositionY = (item - 5) * itemHeight;
			}
			else
			{
				itemPositionX = 0;
				itemPositionY = item * itemHeight;
			}	

			UpdatePosition();
			inventoryExpand.SetActive(true);
		}

		public void HidePanel()
		{

		}

		private void UpdatePosition()
		{
			Vector2 position = new Vector2(inventory.localPosition.x - offsetX + itemPositionX, inventory.localPosition.y + offsetY - itemPositionY);
			inventoryExpand.GetComponent<RectTransform>().localPosition = position;
		}
	}
}