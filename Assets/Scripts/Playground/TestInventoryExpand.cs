using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Playground
{
	public class TestInventoryExpand : EventTrigger
	{
		public override void OnPointerEnter(PointerEventData data)
		{
			//Debug.Log("OnPointerEnter called.");
		}

		public override void OnPointerExit(PointerEventData data)
		{
			gameObject.SetActive(false);
			//Debug.Log("OnPointerExit called.");
		}
	}
}