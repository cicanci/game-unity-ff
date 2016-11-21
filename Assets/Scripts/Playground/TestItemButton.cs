using UnityEngine;
using UnityEngine.UI;
using Prototype.Data;
using System.Collections.Generic;
using Frictionless;

namespace Playground
{
	public class TestItemButton : MonoBehaviour
	{
		public int slodID;

		void Start()
		{
			DataManager dataManager = ServiceFactory.Instance.Resolve<DataManager>();
			string upgradeItemID = dataManager.gameData.ShipSlot[slodID, 0];

			if (!string.IsNullOrEmpty(upgradeItemID))
			{
				List<UpgradeItem> upgradeItemList = dataManager.upgradeItemList.itemList;
				UpgradeItem upgradeItem = upgradeItemList.Find(i => i.ItemID == upgradeItemID);

				Debug.Log(upgradeItem.ItemID);
				GameObject item = Instantiate(upgradeItem.ItemPrefab) as GameObject;
				item.transform.SetParent(transform.parent, false);
				item.GetComponentInChildren<Text>().text = upgradeItem.GetName();
			}
		}
	}
}