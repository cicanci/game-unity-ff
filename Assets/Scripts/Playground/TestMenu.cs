using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Playground
{
    public class TestMenu : MonoBehaviour
    {
        void Start()
        {
            Debug.LogWarning("Playground::TestMenu script is in use by " + gameObject.name);
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (SceneManager.GetActiveScene().name == "Playground")
                {
                    SceneManager.LoadScene("PlaygroundUI");
                }
                else if (SceneManager.GetActiveScene().name == "PlaygroundUI")
                {
                    SceneManager.LoadScene("Playground");
                }
            }
        }
    }

}
