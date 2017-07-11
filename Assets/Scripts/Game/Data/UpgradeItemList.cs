using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu]
    public class UpgradeItemList : ScriptableObject
    {
        public List<UpgradeItem> itemList;
    }
}
