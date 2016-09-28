using UnityEngine;
using System.Collections;

namespace Playground
{
	public class TestBounce : MonoBehaviour 
	{
		private Vector3 tempPos;

		[Range (0, 10)]
		public float amplitude = 0;
		[Range (0, 1)]
		public float speed = 0;

		void Start()
		{
			tempPos = transform.position;
		}

		void Update() 
		{
			tempPos.y = amplitude * Mathf.Sin(speed * Time.time);
			transform.position = tempPos;
		}
	}
}