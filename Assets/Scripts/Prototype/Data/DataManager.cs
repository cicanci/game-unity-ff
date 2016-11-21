using UnityEngine;
using System.Collections;

namespace Prototype.Data
{
	public class DataManager : MonoBehaviour
	{
		public UpgradeItemList upgradeItemList { get; private set; }

		void Awake()
		{
			upgradeItemList = Resources.Load<UpgradeItemList>("Data/UpgradeItemList");
			Debug.Log("upgradeItemList: " + upgradeItemList.itemList.Count);
		}
	}
}