using UnityEngine;
using System.Collections;
using System;

namespace Playground
{
    public class TestSpaceship : MonoBehaviour
    {
        public Transform bulletPosition;
        public float bulletSpeed;
        public GameObject bulletPrefab;

        public float spaceshipSpeed;
        public float spaceshipMovementSpeed;
        public float spaceshipRotationSpeed;
        public GameObject spaceshipCamera;
        private Vector3 cameraPosition;

        void Start()
        {
            Debug.LogWarning("Playground::TestSpaceship script is in use!");
            cameraPosition = spaceshipCamera.transform.localPosition;
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * spaceshipMovementSpeed;
            float v = Input.GetAxis("Vertical") * Time.deltaTime * spaceshipMovementSpeed;

            spaceshipMovement(h, v);
            spaceshipRotation(h, v);
            cameraMovement();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceshipShoot();
            }
        }

        private void cameraMovement()
        {
            spaceshipCamera.transform.localPosition = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + transform.localPosition.z);
        }

        void spaceshipMovement(float h, float v)
        {
            transform.Translate(new Vector3(h, v, Time.deltaTime * spaceshipSpeed));
        }

        void spaceshipRotation(float h, float v)
        {
            if (h > 0)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * spaceshipRotationSpeed);
            }
            else if (h < 0)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * spaceshipRotationSpeed);
            }
            else
            {
                if (transform.rotation.z + Time.deltaTime < 0)
                {
                    transform.Rotate(Vector3.forward * Time.deltaTime * spaceshipRotationSpeed);
                }
                else if (transform.rotation.z - Time.deltaTime > 0)
                {
                    transform.Rotate(Vector3.back * Time.deltaTime * spaceshipRotationSpeed);
                }
            }
        }

        void spaceshipShoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.localPosition, transform.rotation) as GameObject;
            Rigidbody shot = bullet.GetComponent<Rigidbody>();
            shot.AddForce(transform.forward * bulletSpeed);
            Destroy(bullet, 3);
        }
    }

}