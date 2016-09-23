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

		public string shipName;
		public string shipClass;
		[Range (0, 100)]
		public int shipLevel;

        void Start()
        {
            Debug.LogWarning("Playground::TestMenu script is in use by " + gameObject.name);

			UpdateUI();
        }

		void UpdateUI() 
		{
			if (shipNameLabel != null)
			{
				shipNameLabel.text = shipName;
			}

			if (shipClassLabel != null)
			{
				shipClassLabel.text = shipClass;
			}

			if (shipLevelLabel != null)
			{
				shipLevelLabel.text = shipLevel.ToString();
			}
		}
    }

}
