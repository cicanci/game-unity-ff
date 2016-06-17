using UnityEngine;
using System.Collections;

public class Playground : MonoBehaviour 
{
	public Vector3 bulletPosition;
	public float bulletSpeed;
	public GameObject bulletPrefab;

	public float spaceshipSpeed;
	
	void Update () 
	{
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * spaceshipSpeed;
		float v = Input.GetAxis("Vertical") * Time.deltaTime * spaceshipSpeed;

		transform.Translate(new Vector3(h, v, 0f));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(bulletPrefab, bulletPosition, transform.rotation) as GameObject;
			Rigidbody shot = bullet.GetComponent<Rigidbody>();
			shot.AddForce(transform.forward * bulletSpeed);

			Destroy(bullet, 3);
		}
	}
}
