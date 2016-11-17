using UnityEngine;

namespace Prototype
{
    public class Spawner
    {
        private GameObject prototype;

        public Spawner(GameObject prototype)
        {
            this.prototype = prototype;
        }

        public GameObject SpawnObject()
        {
            return GameObject.Instantiate(prototype);
        }
    }

}
