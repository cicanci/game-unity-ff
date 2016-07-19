using UnityEngine;
using System.Collections;

namespace Playground
{
    public class TestAsteroid : MonoBehaviour
    {
        public GameObject modelDestroyed;

		void Start()
		{
			Debug.LogWarning("Playground::TestAsteroid script is in use!");
		}

        void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > 2)
            {
                if (modelDestroyed != null)
                {
                    GameObject destroy = Instantiate(modelDestroyed, transform.position, transform.rotation) as GameObject;
                    Destroy(destroy, 10f);
                }

                Destroy(gameObject, 0.1f);
                Destroy(collision.collider.gameObject);
            }
        }
    }
}