using UnityEngine;

namespace Game.Spaceship
{
    public class SpaceshipControl : MonoBehaviour 
    {
        public float MovementSpeed;
        
        [Range(0, 1)]
        public float MovementLimitTop = 0.7f;
        [Range(0, 1)]
        public float MovementLimitBottom = 0.3f;
        [Range(0, 1)]
        public float MovementLimitLeft = 0.3f;
        [Range(0, 1)]
        public float MovementLimitRight = 0.7f;

        private bool _buttonPressed;

        private void Update() 
        {
            SpaceshipRotation();
            SpaceShipMovement();
        }

        private void SpaceshipRotation()
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");

            if(Input.GetMouseButtonDown(0))
            {
                _buttonPressed = true;
            }

            if(Input.GetMouseButtonUp(0))
            {
                _buttonPressed = false;
            }

            if(_buttonPressed)
            {
                var mousePosition = Input.mousePosition;
                if (mousePosition.x < Screen.width * MovementLimitLeft)
                {
                    horizontalAxis = -1;
                }
                else if (mousePosition.x > Screen.width * MovementLimitRight)
                {
                    horizontalAxis = 1;
                }

                if(mousePosition.y < Screen.height * MovementLimitBottom)
                {
                    verticalAxis = -1;
                }
                else if(mousePosition.y > Screen.height * MovementLimitTop)
                {
                    verticalAxis = 1;
                }
            }
            
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