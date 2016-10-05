using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateCharacterWizard : ScriptableWizard 
{
	public Texture2D portraitTexture;
	public Color color = Color.white;
	public string nickname = "Default nickname";

	[MenuItem ("My Tools/Create Character Wizard")]
	static void CreateWizard()
	{
		ScriptableWizard.DisplayWizard<CreateCharacterWizard> ("Create Character", "Create new", "Update selected");
	}

	void OnWizardCreate()
	{
//		GameObject characterGO = new GameObject ();
//
//		Character characterComponent = characterGO.AddComponent<Character> ();
//		characterComponent.portrait = portraitTexture;
//		characterComponent.color = color;
//		characterComponent.nickname = nickname;
//
//		PlayerMovement playerMovement = characterGO.AddComponent<PlayerMovement> ();
//		characterComponent.playerMovement = playerMovement;
	}

	void OnWizardOtherButton()
	{
		if (Selection.activeTransform != null)
		{
//			Character characterComponent = Selection.activeTransform.GetComponent<Character>();
//
//			if (characterComponent != null)
//			{
//				characterComponent.portrait = portraitTexture;
//				characterComponent.color = color;
//				characterComponent.nickname = nickname;
//			}
		}
	}

	void OnWizardUpdate()
	{
		helpString = "Enter character details";
	}
}