using UnityEngine;

namespace Game.Data
{
    public enum WeaponType
    {
        Primary,
        Special,
        Heavy,
        None
    }

    public enum BonusType
    {
        Attack,
        Cargo,
        Defense,
        Speed
    }

    [CreateAssetMenu]
    public class UpgradeItem : ScriptableObject 
    {
        public string ItemID;
        public BonusType ItemBonus;
        public float BonusValue;
        public WeaponType ItemWeapon;
        public float ItemDurability;
        public GameObject ItemPrefab;

        public string GetName()
        {
            return ItemBonus.ToString() + "\n+" + BonusValue;
        }
    }
}
