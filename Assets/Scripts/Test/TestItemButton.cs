using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Frictionless;
using Game.Data;

namespace Playground
{
	public class TestItemButton : MonoBehaviour
	{
		public int slodID;

		void Start()
		{
			DataManager dataManager = ServiceFactory.Instance.Resolve<DataManager>();
			string upgradeItemID = dataManager.GameData.ShipSlot[slodID, 0];

			if (!string.IsNullOrEmpty(upgradeItemID))
			{
				List<UpgradeItem> upgradeItemList = dataManager.UpgradeItemList.itemList;
				UpgradeItem upgradeItem = upgradeItemList.Find(i => i.ItemID == upgradeItemID);

				GameObject item = Instantiate(upgradeItem.ItemPrefab) as GameObject;
				item.transform.SetParent(transform.parent, false);
				item.GetComponentInChildren<Text>().text = upgradeItem.GetName();
			}
		}
	}
}