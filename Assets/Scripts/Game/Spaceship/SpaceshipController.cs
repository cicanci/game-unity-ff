using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinalFrontier.Game.Spaceship
{
    public class SpaceshipController : MonoBehaviour 
    {
        public float MovementSpeed;

        private void Start() 
        {

        }

        private void Update() 
        {
            SpaceshipRotation();
        }

        private void SpaceshipRotation()
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
            float v = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
            transform.Rotate(v, h, 0);
        }
    }
}