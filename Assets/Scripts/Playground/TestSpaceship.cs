using UnityEngine;
using System.Collections;
using System;

namespace Playground
{
    public class TestSpaceship : MonoBehaviour
    {
        public float speed;
        public float movementSpeed;

		public GameObject bulletPrefab;
		public float bulletSpeed;
		public float bulletTime;

		public Vector3 cameraOffset;

		[Range(0.1f, 1f)]
		public float bias;

        void Start()
        {
			Debug.LogWarning("Playground::TestSpaceship script is in use by " + gameObject.name);
        }

        void Update()
        {
			spaceshipMovement();
			spaceshipRotation();
			spaceshipShoot();
        }

		void LateUpdate()
		{
			cameraMovement();
		}

		void cameraMovement()
		{
			Vector3 moveCamTo = transform.position - transform.forward * cameraOffset.z + Vector3.up * cameraOffset.y;
			Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1 - bias);
			Camera.main.transform.rotation = transform.rotation;
//			Camera.main.transform.LookAt(transform.position + transform.forward * movementSpeed);
		}

        void spaceshipMovement()
        {
			transform.position += transform.forward * Time.deltaTime * speed;
        }

        void spaceshipRotation()
        {
			float h = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
			float v = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
			transform.Rotate(-v, h, 0);
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