using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Prototype.Data
{
	public class DataManager : MonoBehaviour
	{
		public GameData gameData { get; set; }
		public UpgradeItemList upgradeItemList { get; private set; }

		private readonly string fileName = "/game.dat";

		void Awake()
		{
			upgradeItemList = Resources.Load<UpgradeItemList>("Data/UpgradeItemList");
			Debug.Log("upgradeItemList: " + upgradeItemList.itemList.Count);

			//File.Delete(Application.persistentDataPath + fileName);
			Debug.Log("Game Data: " + Application.persistentDataPath + fileName);
		}

		void OnEnable()
		{
			Load();
		}

		void OnDisable()
		{
			Save();
		}

		public void Save()
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath + fileName);

			bf.Serialize(file, gameData);
			file.Close();

			Debug.Log("Game Data Saved");
		}

		public void Load()
		{
			if (File.Exists(Application.persistentDataPath + fileName))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);

				gameData = (GameData)bf.Deserialize(file);
				file.Close();

				Debug.Log("Game Data Loaded");
			}
			else
			{
				gameData = new GameData();
				Debug.Log("New Game Data Created");
			}
		}
	}
}