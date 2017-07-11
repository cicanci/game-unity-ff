using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Loading
{
    public class GameLoading : MonoBehaviour
    {
        public Text LoadingText;
        public int FakeLoadingTime = 3;
        
        private IEnumerator Start()
        {
            for (int i = 0; i < FakeLoadingTime; i++)
            {
                LoadingText.text += ".";
                yield return new WaitForSeconds(1);
            }

            SceneManager.LoadScene(GameConstants.SCENE_UI);
            SceneManager.LoadScene(GameConstants.SCENE_GAME, LoadSceneMode.Additive);
        }
    }
}
