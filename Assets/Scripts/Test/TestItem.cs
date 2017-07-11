using Frictionless;
using Game.Data;
using UnityEngine;

namespace Test
{
    public class TestItem : MonoBehaviour
    {
        private readonly int expandWidth = 250;
        public RectTransform inventory;
        public GameObject inventoryExpand;
        private readonly int itemHeight = 109;
        private int itemPositionX;
        private int itemPositionY;

        private readonly int offsetX = 390;

        private readonly int offsetY = 268;

        //private TestInventoryExpand expand;
        private bool rightColumn;

        private void Start()
        {
            Debug.LogWarning("Playground::TestItem script is in use by " + gameObject.name);

            //expand = inventoryExpand.GetComponent<TestInventoryExpand>();
        }

        private void Update()
        {
            UpdatePosition();
        }

        public void ShowPanel(int item)
        {
            if (item > 4)
            {
                itemPositionX = offsetX * 2 + expandWidth;
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
            //expand.ShowPanel();
        }

        public void HidePanel()
        {
            if (Input.GetAxis("Mouse X") < 0 && rightColumn || Input.GetAxis("Mouse X") > 0 && !rightColumn)
            {
                //expand.HidePanel();
            }
        }

        private void UpdatePosition()
        {
            var position = new Vector2(inventory.localPosition.x - offsetX + itemPositionX,
                inventory.localPosition.y + offsetY - itemPositionY);
            inventoryExpand.GetComponent<RectTransform>().localPosition = position;
        }

        private void UpdateSlots(int slodID)
        {
            var dataManager = ServiceFactory.Instance.Resolve<DataManager>();

            //TestExpandItemButton[] buttons = inventoryExpand.GetComponentsInChildren<TestExpandItemButton>();

            // Ignore the 0 position because it is the active slot item
            for (var i = 1; i < 10; i++)
            {
                var upgradeItemID = dataManager.GameData.ShipSlot[slodID, i];

                if (!string.IsNullOrEmpty(upgradeItemID))
                {
                    var upgradeItemList = dataManager.UpgradeItemList.itemList;
                    var upgradeItem = upgradeItemList.Find(item => item.ItemID == upgradeItemID);
                    Debug.Log(upgradeItem.ItemBonus.ToString());

                    //GameObject upgrade = Instantiate(upgradeItem.ItemPrefab) as GameObject;
                    //buttons[i - 1].gameObject.transform.SetParent(transform.parent, false);
                    //upgrade.GetComponentInChildren<Text>().text = upgradeItem.GetName();
                    //buttons[i - 1].GetComponentInChildren<Text>().text = upgradeItem.GetName();
                }
            }
        }
    }
}