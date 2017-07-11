using Frictionless;
using Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class TestMenu : MonoBehaviour
    {
        [Range(0, 100)] public float shipAttack;

        public Slider shipAttackSlider;

        [Range(0, 100)] public float shipCargo;

        public Slider shipCargoSlider;
        public string shipClass;
        public Text shipClassLabel;

        [Range(0, 100)] public float shipDefense;

        public Slider shipDefenseSlider;

        [Range(0, 100)] public int shipLevel;

        public Text shipLevelLabel;

        public string shipName;
        public Text shipNameLabel;

        [Range(0, 100)] public float shipSpeed;

        public Slider shipSpeedSlider;

        private void Start()
        {
            Debug.LogWarning("Playground::TestMenu script is in use by " + gameObject.name);

            LoadUpgrades();

            UpdateUI();
        }

        private void LoadUpgrades()
        {
            var dataManager = ServiceFactory.Instance.Resolve<DataManager>();
            var upgradeItemList = dataManager.UpgradeItemList.itemList;

            shipLevel = dataManager.GameData.ShipLevel;
            shipName = dataManager.GameData.ShipName;
            shipClass = dataManager.GameData.ShipClass;

            // Attack
            if (!string.IsNullOrEmpty(dataManager.GameData.ShipSlot[0, 0]))
            {
                var upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.GameData.ShipSlot[0, 0]);
                shipAttack = upgradeItem.BonusValue;
            }

            // Defense
            if (!string.IsNullOrEmpty(dataManager.GameData.ShipSlot[1, 0]))
            {
                var upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.GameData.ShipSlot[1, 0]);
                shipDefense = upgradeItem.BonusValue;
            }

            // Speed
            if (!string.IsNullOrEmpty(dataManager.GameData.ShipSlot[2, 0]))
            {
                var upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.GameData.ShipSlot[2, 0]);
                shipSpeed = upgradeItem.BonusValue;
            }

            // Cargo
            if (!string.IsNullOrEmpty(dataManager.GameData.ShipSlot[3, 0]))
            {
                var upgradeItem = upgradeItemList.Find(i => i.ItemID == dataManager.GameData.ShipSlot[3, 0]);
                shipCargo = upgradeItem.BonusValue;
            }
        }

        private void UpdateUI()
        {
            shipNameLabel.text = shipName;
            shipClassLabel.text = shipClass;
            shipLevelLabel.text = shipLevel.ToString("D2");
            shipAttackSlider.value = shipAttack / 100;
            shipDefenseSlider.value = shipDefense / 100;
            shipSpeedSlider.value = shipSpeed / 100;
            shipCargoSlider.value = shipCargo / 100;
        }
    }
}