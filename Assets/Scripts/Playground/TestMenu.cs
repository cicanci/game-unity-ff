using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
        public int shipAttack;
        [Range(0, 100)]
        public int shipDefense;
        [Range(0, 100)]
        public int shipSpeed;
        [Range(0, 100)]
        public int shipCargo;

        void Start()
        {
            Debug.LogWarning("Playground::TestMenu script is in use by " + gameObject.name);
            UpdateUI();
        }

        void UpdateUI() 
        {
            shipNameLabel.text = shipName;
            shipClassLabel.text = shipClass;
            shipLevelLabel.text = shipLevel.ToString();
            shipAttackSlider.value = ((float) shipAttack) / 100;
            shipDefenseSlider.value = ((float)shipDefense) / 100;
            shipSpeedSlider.value = ((float)shipSpeed) / 100;
            shipCargoSlider.value = ((float)shipCargo) / 100;
        }
    }
}
