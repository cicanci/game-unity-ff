using Game;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    public class EditorUtils : MonoBehaviour 
    {
        [MenuItem("Final Frontier/Play %j")]
        public static void Play()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
            else
            {
                EditorSceneManager.OpenScene("Assets/Scenes/" + GameConstants.SCENE_INIT + ".unity");
                EditorApplication.isPlaying = true;
            }
        }
    }
}
