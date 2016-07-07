using UnityEngine;
using System.Collections;
using System;

namespace Playground
{
    public class TestSpaceship : MonoBehaviour
    {
		public Vector2 screenLimit;
        public float speed;
        public float movementSpeed;
        public float rotationSpeed;

        public Boolean cameraFollow;
        public GameObject mainCamera;

		public GameObject bulletPrefab;
		public float bulletSpeed;
		public float bulletTime;
        
        private Vector3 cameraPosition;

        void Start()
        {
            Debug.LogWarning("Playground::TestSpaceship script is in use!");
            cameraPosition = mainCamera.transform.localPosition;
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
            float v = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

            spaceshipMovement(h, v);
            spaceshipRotation(h, v);

            if (cameraFollow)
            {
                cameraMovement();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shoot();
            }
        }

        private void cameraMovement()
        {
            mainCamera.transform.localPosition = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + transform.localPosition.z);
        }

        void spaceshipMovement(float h, float v)
        {
			Vector3 position = transform.localPosition;
			Vector3 translate = new Vector3(0, 0, Time.deltaTime * speed);

			if (Math.Abs(position.x + h) < screenLimit.x)
			{
				translate.x = h;
			}

			if ((position.y + v > 0) && (position.y + v < screenLimit.y))
			{
				translate.y = v;
			}

			// Prevent that the spaceship got stucked in the screen
			if (Math.Abs(position.x) > screenLimit.x)
			{
				translate.x = -h;
			}

			if ((position.y < 0) || (position.y > screenLimit.y))
			{
				translate.y = -v;
			}

			transform.Translate(translate);
        }

        void spaceshipRotation(float h, float v)
        {
            if (h > 0)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
            }
            else if (h < 0)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
            }
            else
            {
                if (transform.rotation.z + Time.deltaTime < 0)
                {
                    transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
                }
                else if (transform.rotation.z - Time.deltaTime > 0)
                {
                    transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
                }
            }
        }

		void shoot()
		{
			GameObject bullet = Instantiate(bulletPrefab, transform.localPosition, transform.rotation) as GameObject;
			Rigidbody shot = bullet.GetComponent<Rigidbody>();
			shot.AddForce(transform.forward * bulletSpeed * speed);
			Destroy(bullet, bulletTime);
		}
    }

}