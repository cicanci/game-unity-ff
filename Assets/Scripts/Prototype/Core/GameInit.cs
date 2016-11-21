using UnityEngine;
using Prototype.Data;
using Frictionless;

namespace Prototype.Core
{
	public class GameInit : MonoBehaviour
	{
		void Awake()
		{
			ServiceFactory.Instance.RegisterSingleton<DataManager>();
		}
	}
}