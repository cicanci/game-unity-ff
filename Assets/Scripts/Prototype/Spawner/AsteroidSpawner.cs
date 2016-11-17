using UnityEngine;
using System.Collections;

namespace Prototype
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject smallAsteroid;
        public int maxSmallAsteroids = 10;

        private Spawner smallAsteroidSpawner;
        private const int MAX_RAND = 300;
        private const int MIN_RAND = -300;

        void Start()
        {
            smallAsteroidSpawner = new Spawner(smallAsteroid);

            for (int i = 1; i <= maxSmallAsteroids; i++)
            {
                GameObject asteroid = smallAsteroidSpawner.SpawnObject();

                float randX = i * Random.Range(MIN_RAND, MAX_RAND);
                float randY = i * Random.Range(MIN_RAND, MAX_RAND);
                float randZ = i * Random.Range(MIN_RAND, MAX_RAND);
                asteroid.transform.localPosition = new Vector3(randX, randY, randZ);
            }
        }
    }
}
