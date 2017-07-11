using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameInit : MonoBehaviour 
    {
        private void Start() 
        {
            if (Application.isEditor)
            {
                Application.runInBackground = true;
            }

            SceneManager.LoadScene(GameConstants.SCENE_LOADING);
        }
    }
}
