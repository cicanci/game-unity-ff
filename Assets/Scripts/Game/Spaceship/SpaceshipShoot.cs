using System.Collections;
using UnityEngine;

namespace Game.Spaceship
{
    public class SpaceshipShoot : MonoBehaviour
    {
        public float FireRate = 0.25f;
        public float WeaponRange = 50;
        public float HitForce = 100;
        public float FireDuration = 0.07f;
        public Transform GunEnd;

        private Camera _fpsCam;
        private LineRenderer _laserLine;
        private float _nextFire;

        private void Start() 
        {
            _laserLine = GetComponent<LineRenderer>();
            _fpsCam = Camera.main;
        }

        private void Update() 
        {
            if(Input.GetButtonDown("Fire1") && Time.time > _nextFire) 
            {
                _nextFire = Time.time + FireRate;

                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = _fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                _laserLine.SetPosition(0, GunEnd.position);

                RaycastHit hit;
                if(Physics.Raycast(rayOrigin, _fpsCam.transform.forward, out hit, WeaponRange))
                {
                    _laserLine.SetPosition(1, hit.point);

                    if(hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * HitForce);
                    }

                    //Asteroid asteroid = hit.collider.gameObject.GetComponent<Asteroid>();
                    //if(asteroid != null)
                    //{
                    //    asteroid.DestroyAsteroid(hit.collider.gameObject, -hit.normal * HitForce);
                    //}
                }
                else
                {
                    _laserLine.SetPosition(1, rayOrigin + (_fpsCam.transform.forward * WeaponRange));
                }
            }
        }

        private IEnumerator ShotEffect()
        {
            _laserLine.enabled = true;
            yield return new WaitForSeconds(FireDuration);
            _laserLine.enabled = false;
        }
    }
}