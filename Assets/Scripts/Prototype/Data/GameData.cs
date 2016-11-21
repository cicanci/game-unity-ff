using System.Collections.Generic;
using System;

namespace Prototype.Data
{
	[Serializable]
	public class GameData
	{
		public int ShipLevel { get; set; }
		public string[,] ShipSlot { get; set; }

		public GameData()
		{
			ShipLevel = 1;
			// Create 10 ship slots with 10 items on each
			ShipSlot = new string[10, 10];

			// FIXME: Init the game data with some test items
			ShipSlot[0, 0] = "TEST_ATTACK";
			ShipSlot[1, 0] = "TEST_DEFENSE";
			ShipSlot[2, 0] = "TEST_SPEED";
			ShipSlot[3, 0] = "TEST_CARGO";
		}
	}
}