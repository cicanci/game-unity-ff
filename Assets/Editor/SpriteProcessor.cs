using UnityEngine;
using System.Collections;
using UnityEditor;

public class SpriteProcessor : AssetPostprocessor 
{
	void OnPostprocessTexture(Texture2D texture)
	{
		string lowerCaseAssetPath = assetPath.ToLower();
		bool isInSpritesDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;

		if (isInSpritesDirectory)
		{
			TextureImporter textureImporter = (TextureImporter)assetImporter;
			textureImporter.textureType = TextureImporterType.Sprite;

			Debug.Log("Texture2D converted to Sprite");
		}
	}
}
