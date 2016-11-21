using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Prototype.Data;
using System.Collections.Generic;
using Frictionless;
using Prototype.Core;

namespace Playground
{
	public class TestItemButton : MonoBehaviour
	{
		public string slodID;

		void Start()
		{
			// TODO: Get the upgrateItemID in the slotID
			string upgradeItemID = "TEST_ATTACK";

			DataManager dataManager = ServiceFactory.Instance.Resolve<DataManager>();
			List<UpgradeItem> upgradeItemList = dataManager.upgradeItemList.itemList;
			UpgradeItem upgradeItem = upgradeItemList.Find(i => i.ItemID == upgradeItemID);

			Debug.Log(upgradeItem.ItemID);
			GameObject item = Instantiate(upgradeItem.ItemPrefab) as GameObject;
			item.transform.SetParent(transform.parent, false);
			item.GetComponentInChildren<Text>().text = upgradeItem.GetName();
		}
	}
}