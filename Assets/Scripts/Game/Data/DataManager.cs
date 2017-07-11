using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Game.Data
{
    public class DataManager : MonoBehaviour
    {
        public GameData GameData { get; set; }
        public UpgradeItemList UpgradeItemList { get; private set; }

        private readonly string _fileName = "/game.dat";

        private void Awake()
        {
            UpgradeItemList = Resources.Load<UpgradeItemList>("Data/UpgradeItemList");
            Debug.Log("upgradeItemList: " + UpgradeItemList.itemList.Count);

            File.Delete(Application.persistentDataPath + _fileName);
            Debug.Log("Game Data: " + Application.persistentDataPath + _fileName);
        }

        private void OnEnable()
        {
            Load();
        }

        private void OnDisable()
        {
            Save();
        }

        public void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + _fileName);

            bf.Serialize(file, GameData);
            file.Close();

            Debug.Log("Game Data Saved");
        }

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + _fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + _fileName, FileMode.Open);

                GameData = (GameData)bf.Deserialize(file);
                file.Close();

                Debug.Log("Game Data Loaded");
            }
            else
            {
                GameData = new GameData();
                Debug.Log("New Game Data Created");
            }
        }
    }
}