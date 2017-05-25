using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinalFrontier.Game.Spaceship
{
    public class SpaceshipController : MonoBehaviour 
    {
        [Range(0.1f, 1f)]
        public float Bias;
        public Vector3 CameraOffset;
        public float MovementSpeed;

        private void Start() 
        {

        }

        private void Update() 
        {
            SpaceshipRotation();
            SpaceShipMovement();
        }

        private void LateUpdate()
        {
            CameraFollow();
        }

        private void CameraFollow()
        {
            Vector3 moveCamTo = transform.position - transform.forward * CameraOffset.z + Vector3.up * CameraOffset.y;
            Camera.main.transform.position = Camera.main.transform.position * Bias + moveCamTo * (1 - Bias);
            Camera.main.transform.rotation = transform.rotation;
            //Camera.main.transform.LookAt(transform.position + transform.forward * MovementSpeed);
        }

        private void SpaceshipRotation()
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
            float v = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
            transform.Rotate(v, h, 0);
        }

        private void SpaceShipMovement()
        {
            transform.position += transform.forward * Time.deltaTime * MovementSpeed;
        }
    }
}