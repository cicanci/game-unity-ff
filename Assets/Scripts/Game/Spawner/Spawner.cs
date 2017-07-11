using UnityEngine;

namespace Game.Spawner
{
    public class Spawner
    {
        private readonly GameObject _prototype;

        public Spawner(GameObject prototype)
        {
            this._prototype = prototype;
        }

        public GameObject SpawnObject()
        {
            return Object.Instantiate(_prototype);
        }
    }

}
