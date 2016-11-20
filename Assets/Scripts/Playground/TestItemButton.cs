using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Prototype.Data;

namespace Playground
{
	public class TestItemButton : MonoBehaviour
	{
		public UpgradeItem upgrateItem;
		public string upgradeItemID;

		void Start()
		{
			Debug.Log(upgrateItem.ItemID);
			GameObject item = Instantiate(upgrateItem.ItemPrefab) as GameObject;
			item.transform.SetParent(transform.parent, false);
		}
	}
}