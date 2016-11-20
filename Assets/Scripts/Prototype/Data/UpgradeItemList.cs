using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Prototype.Data
{
	[CreateAssetMenu]
	public class UpgradeItemList : ScriptableObject
	{
		public List<UpgradeItem> itemList;
	}
}
