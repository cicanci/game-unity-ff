using UnityEngine;

namespace Game.Spaceship
{
    public class SpaceshipController : MonoBehaviour 
    {
        public float MovementSpeed;

        private void Update() 
        {
            SpaceshipRotation();
            SpaceShipMovement();
        }

        private void SpaceshipRotation()
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");
            
            float h = horizontalAxis * Time.deltaTime * MovementSpeed;
            float v = verticalAxis * Time.deltaTime * -MovementSpeed;
            transform.Rotate(v, h, 0);
        }

        private void SpaceShipMovement()
        {
            transform.position += transform.forward * Time.deltaTime * MovementSpeed;
        }
    }
}