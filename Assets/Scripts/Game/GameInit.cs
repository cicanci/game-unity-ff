using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameInit : MonoBehaviour 
    {
        private void Start() 
        {
            SceneManager.LoadScene(GameConstants.SCENE_LOADING);
        }
    }
}
