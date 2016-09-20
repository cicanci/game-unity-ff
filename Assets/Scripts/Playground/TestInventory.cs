using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Playground
{
    public enum UIType
    {
        UICanvas, UIObject, None
    }

    public class TestInventory : MonoBehaviour
    {
        [Range(0, 100)]
        public float horizontalSpeed = 0;
		[Range(0, 100)]
		public float verticalSpeed = 0;
        public UIType type = UIType.None;
        public bool inverted = false;

        void Start()
        {
            Debug.LogWarning("Playground::TestInventory script is in use by " + gameObject.name);
        }

        void Update()
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
				StartCoroutine(moveObject(Vector3.left, Time.deltaTime * horizontalSpeed));
            }

            if (Input.GetAxis("Mouse X") > 0)
            {
				StartCoroutine(moveObject(Vector3.right, Time.deltaTime * horizontalSpeed));
            }

            if (Input.GetAxis("Mouse Y") < 0)
            {
				StartCoroutine(moveObject(((inverted) ? Vector3.up : Vector3.down), Time.deltaTime * verticalSpeed));
            }

            if (Input.GetAxis("Mouse Y") > 0)
            {
				StartCoroutine(moveObject(((inverted) ? Vector3.down : Vector3.up), Time.deltaTime * verticalSpeed));
            }
        }

		IEnumerator moveObject(Vector3 direction, float speed)
		{
			Vector3 destination = Vector3.zero;

			switch (type)
			{
			case UIType.UICanvas:
				gameObject.GetComponent<RectTransform>().Translate(direction * speed);
				break;
			case UIType.UIObject:
				gameObject.transform.Translate(direction * speed);
				break;
			case UIType.None:
				Debug.LogWarning("No UIType set for " + gameObject.name);
				break;
			default:
				break;
			}

			yield return null;
		}
    }
}