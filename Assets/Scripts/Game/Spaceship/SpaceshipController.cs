using UnityEngine;

namespace FinalFrontier.Game.Spaceship
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
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
            float v = Input.GetAxis("Vertical") * Time.deltaTime * -MovementSpeed;
            transform.Rotate(v, h, 0);
        }

        private void SpaceShipMovement()
        {
            transform.position += transform.forward * Time.deltaTime * MovementSpeed;
        }
    }
}