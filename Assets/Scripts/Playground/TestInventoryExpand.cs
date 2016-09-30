using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Playground
{
	public class TestInventoryExpand : EventTrigger
	{
		private bool expanded = false;

		public override void OnPointerEnter(PointerEventData data)
		{
			Debug.Log("OnPointerEnter called.");
		}

		public override void OnPointerExit(PointerEventData data)
		{
			HidePanel();
			Debug.Log("OnPointerExit called.");
		}

		public bool IsExpanded()
		{
			return expanded;
		}

		public void ShowPanel()
		{
			expanded = true;
			gameObject.SetActive(true);
		}

		public void HidePanel()
		{
			expanded = false;
			gameObject.SetActive(false);
		}
	}
}