using UnityEngine;
using System.Collections;
using System;

namespace Playground
{
    public class TestSpaceship : MonoBehaviour
    {
        public float speed;
        public float movementSpeed;
        public float rotationSpeed;

		public GameObject bulletPrefab;
		public float bulletSpeed;
		public float bulletTime;

        void Start()
        {
			Debug.LogWarning("Playground::TestSpaceship script is in use by " + gameObject.name);
        }

        void Update()
        {
			cameraMovement();
			spaceshipMovement();
			spaceshipRotation();
			spaceshipShoot();
        }

		void cameraMovement()
		{
			// TODO: Need to remove these magic numbers
			Vector3 moveCamTo = transform.position - transform.forward * 80 + Vector3.up * 20;
			float bias = 0.96f;

			Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1 - bias);
			Camera.main.transform.LookAt(transform.position + transform.forward * movementSpeed);
		}

        void spaceshipMovement()
        {
			transform.position += transform.forward * Time.deltaTime * speed;
        }

        void spaceshipRotation()
        {
			float h = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
			float v = Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;
			transform.Rotate(-v, 0, -h);
        }

		void spaceshipShoot()
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
			{
				GameObject bullet = Instantiate(bulletPrefab, transform.localPosition, transform.rotation) as GameObject;
				Rigidbody shot = bullet.GetComponent<Rigidbody>();
				shot.AddForce(transform.forward * bulletSpeed * speed);
				Destroy(bullet, bulletTime);
			}
		}
    }

}