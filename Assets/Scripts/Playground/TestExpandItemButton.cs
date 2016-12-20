using UnityEngine;

namespace Playground
{
	public class TestExpandItemButton : MonoBehaviour
	{
		public void OnClickItem(int buttonId)
		{
			Debug.Log("Clicked on " + buttonId);
		}
	}
}