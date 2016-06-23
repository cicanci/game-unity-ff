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

		public Vector2 spaceshipScreenLimit;
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
			Vector3 position = transform.localPosition;
			Vector3 translate = new Vector3(0, 0, Time.deltaTime * spaceshipSpeed);

			if (Math.Abs(position.x + h) < spaceshipScreenLimit.x)
			{
				translate.x = h;
			}

			if ((position.y + v > 0) && (position.y + v < spaceshipScreenLimit.y))
			{
				translate.y = v;
			}

			// Prevent that the spaceship got stucked in the screen
			if (Math.Abs(position.x) > spaceshipScreenLimit.x)
			{
				translate.x = -h;
			}

			if ((position.y < 0) || (position.y > spaceshipScreenLimit.y))
			{
				translate.y = -v;
			}

			transform.Translate(translate);
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
            Destroy(bullet, 10);
        }
    }

}