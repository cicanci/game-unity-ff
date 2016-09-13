using UnityEngine;
using System.Collections;

namespace Playground
{
    public class TestPlanet : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(Vector3.right * Time.deltaTime);
        }
    }
}
