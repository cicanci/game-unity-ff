using UnityEngine;

namespace Game.Behaviour
{
    public class FloatingBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _amplitude;

        [SerializeField]
        private float _speed;

        private float _tempVal;
        private Vector3 _tempPos;

        private void Start()
        {
            _tempPos = transform.position;
            _tempVal = transform.position.y;
        }

        private void Update()
        {
            _tempPos.y = _tempVal + _amplitude * Mathf.Sin(_speed * Time.time);
            transform.position = _tempPos;
        }
    }
}
