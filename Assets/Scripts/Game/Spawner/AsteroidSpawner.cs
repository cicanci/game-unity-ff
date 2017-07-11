using UnityEngine;

namespace Game.Spawner
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject SmallAsteroid;
        public int MaxSmallAsteroids = 10;
        public int MaxRand = 300;
        public int MinRand = -300;

        private Spawner _smallAsteroidSpawner;

        private void Start()
        {
            _smallAsteroidSpawner = new Spawner(SmallAsteroid);

            for (int i = 1; i <= MaxSmallAsteroids; i++)
            {
                GameObject asteroid = _smallAsteroidSpawner.SpawnObject();

                float randX = i * Random.Range(MinRand, MaxRand);
                float randY = i * Random.Range(MinRand, MaxRand);
                float randZ = i * Random.Range(MinRand, MaxRand);
                asteroid.transform.localPosition = new Vector3(randX, randY, randZ);
            }
        }
    }
}
