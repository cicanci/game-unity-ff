using UnityEngine;
using System.Collections;
using UnityEditor;

public class SelectAllOfTag : ScriptableWizard 
{
	public string searchTag = "Your tag here";

	[MenuItem("My Tools/Select All Of Tag")]
	static void SelectAllOfTagWizard()
	{
		ScriptableWizard.DisplayWizard<SelectAllOfTag>("Select All Of Tag", "Make Selection");
	}

	void OnWizardCreate()
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
		Selection.objects = gameObjects;
	}
}
