using UnityEngine;
using UnityEngine.UI;
using Prototype.Data;
using Frictionless;
using System.Collections.Generic;

namespace Playground
{
    public class TestMenu : MonoBehaviour
    {
        public Text shipNameLabel;
        public Text shipClassLabel;
        public Text shipLevelLabel;
        public Slider shipAttackSlider;
        public Slider shipDefenseSlider;
        public Slider shipSpeedSlider;
        public Slider shipCargoSlider;

        public string shipName;
        public string shipClass;
        [Range (0, 100)]
        public int shipLevel;
        [Range(0, 100)]
        public float shipAttack;
        [Range(0, 100)]
        public float shipDefense;
        [Range(0, 100)]
        public float shipSpeed;
        [Range(0, 100)]
        public float shipCargo;

        void Start()
        {
            Debug.LogWarning("Playground::TestMenu script is in use by " + gameObject.name);

			LoadUpgrades();

            UpdateUI();
        }

		void LoadUpgrades()
		{
			DataManager dataManager = ServiceFactory.Instance.Resolve<DataManager>();
			List<UpgradeItem> upgradeItemList = dataManager.upgradeItemList.itemList;

			// Level
			shipLevel = dataManager.gameData.ShipLevel;

			// Attack
			if (!string.IsNullOrEmpty(dataManager.gameData.ShipSlot[0, 0]))
			{
				UpgradeItem upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.gameData.ShipSlot[0, 0]);
				shipAttack = upgradeItem.BonusValue;
			}

			// Defense
			if (!string.IsNullOrEmpty(dataManager.gameData.ShipSlot[1, 0]))
			{
				UpgradeItem upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.gameData.ShipSlot[1, 0]);
				shipDefense = upgradeItem.BonusValue;
			}

			// Speed
			if (!string.IsNullOrEmpty(dataManager.gameData.ShipSlot[2, 0]))
			{
				UpgradeItem upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.gameData.ShipSlot[2, 0]);
				shipSpeed = upgradeItem.BonusValue;
			}

			// Cargo
			if (!string.IsNullOrEmpty(dataManager.gameData.ShipSlot[3, 0]))
			{
				UpgradeItem upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.gameData.ShipSlot[3, 0]);
				shipCargo = upgradeItem.BonusValue;
			}
		}

		void UpdateUI() 
        {
            shipNameLabel.text = shipName;
            shipClassLabel.text = shipClass;
            shipLevelLabel.text = shipLevel.ToString();
            shipAttackSlider.value = shipAttack / 100;
            shipDefenseSlider.value = shipDefense / 100;
            shipSpeedSlider.value = shipSpeed / 100;
            shipCargoSlider.value = shipCargo / 100;
        }
    }
}
