using System.Collections.Generic;
using System;

namespace Prototype.Data
{
	[Serializable]
	public class GameData
	{
		public int ShipLevel { get; set; }
		public string ShipName { get; set; }
		public string ShipClass { get; set; }
		public string[,] ShipSlot { get; set; }

		public GameData()
		{
			// Start at level 1
			ShipLevel = 1;
			// Create 10 ship slots with 10 items on each
			ShipSlot = new string[10, 10];

			// FIXME: Init the game data with some test items
			ShipName = "Imperial Fighter";
			ShipClass = "Star Empire Ship";
			ShipSlot[0, 0] = "TEST_ATTACK";
			ShipSlot[0, 1] = "TEST_DEFENSE";
			ShipSlot[0, 2] = "TEST_SPEED";
			ShipSlot[0, 3] = "TEST_CARGO";
			ShipSlot[1, 0] = "TEST_DEFENSE";
			ShipSlot[2, 0] = "TEST_SPEED";
			ShipSlot[3, 0] = "TEST_CARGO";
		}
	}
}