using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Frictionless;
using Game.Data;

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
        private TestInventoryExpand expand;
        private bool rightColumn = false;

        void Start()
        {
            Debug.LogWarning("Playground::TestItem script is in use by " + gameObject.name);

            expand = inventoryExpand.GetComponent<TestInventoryExpand>();
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
                rightColumn = true;
            }
            else
            {
                itemPositionX = 0;
                itemPositionY = item * itemHeight;
                rightColumn = false;
            }

            UpdatePosition();
			UpdateSlots(item);
            expand.ShowPanel();
        }

        public void HidePanel()
        {
            if (((Input.GetAxis("Mouse X") < 0) && (rightColumn)) || ((Input.GetAxis("Mouse X") > 0) && (!rightColumn)))
            {
                expand.HidePanel();
            }
        }

        private void UpdatePosition()
        {
            Vector2 position = new Vector2(inventory.localPosition.x - offsetX + itemPositionX, inventory.localPosition.y + offsetY - itemPositionY);
            inventoryExpand.GetComponent<RectTransform>().localPosition = position;
        }

		private void UpdateSlots(int slodID)
		{
			DataManager dataManager = ServiceFactory.Instance.Resolve<DataManager>();

			TestExpandItemButton[] buttons = inventoryExpand.GetComponentsInChildren<TestExpandItemButton>();

			// Ignore the 0 position because it is the active slot item
			for (int i = 1; i < 10; i++)
			{
				string upgradeItemID = dataManager.GameData.ShipSlot[slodID, i];

				if (!string.IsNullOrEmpty(upgradeItemID))
				{
					List<UpgradeItem> upgradeItemList = dataManager.UpgradeItemList.itemList;
					UpgradeItem upgradeItem = upgradeItemList.Find(item => item.ItemID == upgradeItemID);
					Debug.Log(upgradeItem.ItemBonus.ToString());

					//GameObject upgrade = Instantiate(upgradeItem.ItemPrefab) as GameObject;
					//buttons[i - 1].gameObject.transform.SetParent(transform.parent, false);
					//upgrade.GetComponentInChildren<Text>().text = upgradeItem.GetName();
					buttons[i - 1].GetComponentInChildren<Text>().text = upgradeItem.GetName();
				}
				else
				{
					buttons[i - 1].GetComponentInChildren<Text>().text = string.Empty;
				}
			}
		}
    }
}