using UnityEngine;
using System.Collections;

namespace Playground
{
    public class TestBullet : MonoBehaviour
    {
        public Transform bulletPosition;
        public float bulletSpeed;
        public float bulletTime;
        public GameObject bulletPrefab;

        void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        public void shoot(float spaceShipSpeed)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.localPosition, transform.rotation) as GameObject;
            Rigidbody shot = bullet.GetComponent<Rigidbody>();
            shot.AddForce(transform.forward * bulletSpeed * spaceShipSpeed);
            Destroy(bullet, bulletTime);
        }
    }
}