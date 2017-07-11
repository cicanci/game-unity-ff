using UnityEngine;
using System.Collections;

namespace Playground
{
    public class TestPlanet : MonoBehaviour
    {
        void Start ()
        {
            Debug.LogWarning ("Playground::TestPlanet script is in use by " + gameObject.name);
        }

        void Update ()
        {
            transform.Rotate (Vector3.right * Time.deltaTime);
        }
    }
}
