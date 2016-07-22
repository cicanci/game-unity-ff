using UnityEngine;
using System.Collections;

namespace Playground
{
    public class TestAsteroid : MonoBehaviour
    {
        public GameObject modelDestroyed;

		void Start()
		{
			Debug.LogWarning("Playground::TestAsteroid script is in use by " + gameObject.name);
		}

        void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > 2)
            {
                if (modelDestroyed != null)
                {
                    GameObject destroy = Instantiate(modelDestroyed, transform.position, transform.rotation) as GameObject;
					// Asteroid destroyed model
                    //Destroy(destroy, 10f);
                }

				// Bullet model
                Destroy(gameObject, 0.1f);
				// Asteroid model
                Destroy(collision.collider.gameObject);
            }
        }
    }
}