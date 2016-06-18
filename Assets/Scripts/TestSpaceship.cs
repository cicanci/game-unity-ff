using UnityEngine;
using System.Collections;

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

        void Start()
        {
            Debug.LogWarning("Playground::TestSpaceship script is in use!");
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * spaceshipMovementSpeed;
            float v = Input.GetAxis("Vertical") * Time.deltaTime * spaceshipMovementSpeed;

            spaceshipMovement(h, v);
            spaceshipRotation(h, v);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceshipShoot();
            }
        }

        void spaceshipMovement(float h, float v)
        {
            transform.Translate(new Vector3(h, v, 0f));
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