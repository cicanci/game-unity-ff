using UnityEngine;
using System.Collections;

namespace Playground
{
	public class TestAsteroid : MonoBehaviour
	{
		public GameObject modelDestroyed;

		void Start ()
		{
			Debug.LogWarning ("Playground::TestAsteroid script is in use by " + gameObject.name);
		}

		void OnCollisionEnter (Collision collision)
		{
			//if (collision.relativeVelocity.magnitude > 0)
			{
				DestroyAsteroid (gameObject, collision.impulse);
			}
		}

		public void DestroyAsteroid (GameObject asteroid, Vector3 force)
		{
			// Asteroid normal model
			Destroy (asteroid);

			if (modelDestroyed != null) {
				GameObject destroy = Instantiate (modelDestroyed, transform.position, transform.rotation) as GameObject;

				Rigidbody piece = destroy.GetComponentInChildren<Rigidbody> ();
				piece.velocity = force;

				Destroy (destroy, 10f);
			}
		}
	}
}