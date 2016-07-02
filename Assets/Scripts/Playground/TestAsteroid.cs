using UnityEngine;
using System.Collections;

namespace Playground
{
    public class TestAsteroid : MonoBehaviour
    {
        public GameObject modelDestroyed;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > 2)
            {
                if (modelDestroyed != null)
                {
                    Instantiate(modelDestroyed, transform.position, transform.rotation);
                }

                Destroy(gameObject);
                //Destroy(collision.collider.gameObject);
            }
        }
    }
}